using System;
using System.Net;
using System.Net.Sockets;

namespace TrafficStatistics.Relay
{
    public class TCPPipe
    {
        private IRelay _relay;
        private EndPoint _localEP;
        private EndPoint _remoteEP;

        public TCPPipe(IRelay relay, EndPoint localEP, EndPoint remoteEP)
        {
            _relay = relay;
            _localEP = localEP;
            _remoteEP = remoteEP;
        }

        public bool CreatePipe(Socket socket)
        {
            new Handler(_relay, _localEP, _remoteEP).Start(socket);
            return true;
        }

        class Handler
        {
            private IRelay _relay;
            private EndPoint _localEP;
            private EndPoint _remoteEP;

            private Socket _local;
            private Socket _remote;
            private bool _closed = false;
            public const int RecvSize = 16384;
            // remote receive buffer
            private byte[] remoteRecvBuffer = new byte[RecvSize];
            // connection receive buffer
            private byte[] connetionRecvBuffer = new byte[RecvSize];
            private int _remoteTime;
            private int _id;

            private static int _maxid = 0;

            public Handler(IRelay relay, EndPoint localEP, EndPoint remoteEP)
            {
                _relay = relay;
                _localEP = localEP;
                _remoteEP = remoteEP;
            }

            public void Start(Socket socket)
            {
                this._local = socket;
                try
                {
                    _remote = new Socket(_remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    _remote.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

                    _id = System.Threading.Interlocked.Increment(ref _maxid);

                    // Connect to the remote endpoint.
                    _relay.onWriteLog(new WriteLogEventArgs($"\r\n{_id}: 连接 {_remoteEP} ...\r\n"));
                    _remoteTime = Environment.TickCount;
                    _remote.BeginConnect(_remoteEP, new AsyncCallback(ConnectCallback), null);
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void ConnectCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    _relay.onWriteLog(new WriteLogEventArgs($"{_id}: 已连接 {_remoteEP}，耗时 {Environment.TickCount - _remoteTime} 毫秒\r\n"));
                    _remoteTime = Environment.TickCount;
                    _remote.EndConnect(ar);
                    StartPipe();
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void StartPipe()
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    _remote.BeginReceive(remoteRecvBuffer, 0, RecvSize, 0, new AsyncCallback(PipeRemoteReceiveCallback), null);
                    _local.BeginReceive(connetionRecvBuffer, 0, RecvSize, 0, new AsyncCallback(PipeConnectionReceiveCallback), null);
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void PipeRemoteReceiveCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    int bytesRead = _remote.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        _relay.onWriteLog(new WriteLogEventArgs($"{_id}: 接收到 {_remoteEP} 的数据，耗时 {Environment.TickCount - _remoteTime} 毫秒\r\n"));
                        _remoteTime = Environment.TickCount;
                        var e = new RelayEventArgs(remoteRecvBuffer, 0, bytesRead);
                        _relay.onOutbound(e);
                        _local.BeginSend(e.Buffer, e.Offset, e.Length, 0, new AsyncCallback(PipeConnectionSendCallback), null);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void PipeConnectionReceiveCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    int bytesRead = _local.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        var e = new RelayEventArgs(connetionRecvBuffer, 0, bytesRead);
                        _relay.onInbound(e);
                        _relay.onWriteLog(new WriteLogEventArgs($"{_id}: 发送 {bytesRead} 字节到 {_remoteEP} ...\r\n"));
                        _remoteTime = Environment.TickCount;
                        _remote.BeginSend(e.Buffer, e.Offset, e.Length, 0, new AsyncCallback(PipeRemoteSendCallback), null);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void PipeRemoteSendCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    _relay.onWriteLog(new WriteLogEventArgs($"{_id}: 已发送到 {_remoteEP}，耗时 {Environment.TickCount - _remoteTime} 毫秒\r\n"));
                    _remoteTime = Environment.TickCount;
                    _remote.EndSend(ar);
                    _local.BeginReceive(this.connetionRecvBuffer, 0, RecvSize, 0,
                        new AsyncCallback(PipeConnectionReceiveCallback), null);
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void PipeConnectionSendCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    _local.EndSend(ar);
                    _remote.BeginReceive(this.remoteRecvBuffer, 0, RecvSize, 0,
                        new AsyncCallback(PipeRemoteReceiveCallback), null);
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            public void Close()
            {
                lock (this)
                {
                    if (_closed)
                    {
                        return;
                    }
                    _closed = true;
                }
                if (_local != null)
                {
                    try
                    {
                        _local.Shutdown(SocketShutdown.Both);
                        _local.Close();
                        _local = null;
                        connetionRecvBuffer = null;
                    }
                    catch (Exception e)
                    {
                        _relay.onError(new RelayErrorEventArgs(e));
                    }
                }
                if (_remote != null)
                {
                    try
                    {
                        _remote.Shutdown(SocketShutdown.Both);
                        _remote.Close();
                        _remote = null;
                        remoteRecvBuffer = null;
                    }
                    catch (SocketException e)
                    {
                        _relay.onError(new RelayErrorEventArgs(e));
                    }
                }
            }
        }
    }
}
