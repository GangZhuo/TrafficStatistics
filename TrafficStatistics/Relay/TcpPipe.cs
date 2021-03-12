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
        private EndPoint _socks5EP;
        private bool _useProxy;

        public TCPPipe(IRelay relay, EndPoint localEP, EndPoint remoteEP, EndPoint socks5EP, bool useProxy)
        {
            _relay = relay;
            _localEP = localEP;
            _remoteEP = remoteEP;
            _socks5EP = socks5EP;
            _useProxy = useProxy;
        }

        public bool CreatePipe(Socket socket)
        {
            new Handler(_relay, _localEP, _remoteEP, _socks5EP, _useProxy).Start(socket);
            return true;
        }

        class Handler
        {
            private IRelay _relay;
            private EndPoint _localEP;
            private EndPoint _remoteEP;
            private EndPoint _socks5EP;
            private bool _useProxy;

            private Socket _local;
            private Socket _remote;
            private bool _closed = false;
            public const int RecvSize = 16384;
            // remote receive buffer
            private byte[] remoteRecvBuffer = new byte[RecvSize];
            // connection receive buffer
            private byte[] connetionRecvBuffer = new byte[RecvSize];
            private int _id;

            private static int _maxid = 0;

            public Handler(IRelay relay, EndPoint localEP, EndPoint remoteEP, EndPoint socks5EP, bool useProxy)
            {
                _relay = relay;
                _localEP = localEP;
                _remoteEP = remoteEP;
                _socks5EP = socks5EP;
                _useProxy = useProxy;
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
                    _remote.BeginConnect(
                        _useProxy ? _socks5EP : _remoteEP,
                        new AsyncCallback(ConnectCallback), null);
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private int SOCKS5_FIRST_PACKAGE_SIZE = 3;

            private void ConnectCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    _remote.EndConnect(ar);
                    if (_useProxy)
                    {
                        var bytes = new byte[256];
                        var i = 0;
                        bytes[i++] = 0x05;
                        bytes[i++] = 0x01;
                        bytes[i++] = 0x00;
                        SOCKS5_FIRST_PACKAGE_SIZE = i;
                        bytes[i++] = 0x05;
                        bytes[i++] = 0x01;
                        bytes[i++] = 0x00;
                        if (_remoteEP.AddressFamily == AddressFamily.InterNetwork)
                        {
                            bytes[i++] = 0x01;
                            var ipbytes = ((IPEndPoint)_remoteEP).Address.GetAddressBytes();
                            for (var j = 0; j < 4; j++) bytes[i++] = ipbytes[j];
                            var port = ((IPEndPoint)_remoteEP).Port;
                            bytes[i++] = (byte)((port >> 8) & 0xFF);
                            bytes[i++] = (byte)((port >> 0) & 0xFF);
                        }
                        else
                        {
                            bytes[i++] = 0x04;
                            var ipbytes = ((IPEndPoint)_remoteEP).Address.GetAddressBytes();
                            for (var j = 0; j < 16; j++) bytes[i++] = ipbytes[j];
                            var port = ((IPEndPoint)_remoteEP).Port;
                            bytes[i++] = (byte)((port >> 8) & 0xFF);
                            bytes[i++] = (byte)((port >> 0) & 0xFF);
                        }

                        _remote.BeginSend(bytes, 0, SOCKS5_FIRST_PACKAGE_SIZE,
                            SocketFlags.None,
                            new AsyncCallback(Socks5Handshake1SendCallback),
                            new object[] { bytes, i });
                    }
                    else
                    {
                        StartPipe();
                    }
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void Socks5Handshake1SendCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    var len = _remote.EndSend(ar);
                    if (len == SOCKS5_FIRST_PACKAGE_SIZE)
                    {
                        _remote.BeginReceive(remoteRecvBuffer, 0, 2, 0,
                            new AsyncCallback(Socks5Handshake1RecvCallback), ar.AsyncState);
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

            private void Socks5Handshake1RecvCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    var len = _remote.EndReceive(ar);
                    if (len == 2)
                    {
                        if (remoteRecvBuffer[0] == 0x05 && remoteRecvBuffer[1] == 0x00)
                        {
                            var bytes = (byte[])((object[])ar.AsyncState)[0];
                            var bytesLen = (int)((object[])ar.AsyncState)[1];
                            _remote.BeginSend(bytes, 
                                SOCKS5_FIRST_PACKAGE_SIZE,
                                bytesLen - SOCKS5_FIRST_PACKAGE_SIZE,
                                SocketFlags.None,
                                new AsyncCallback(Socks5Handshake2SendCallback), ar.AsyncState);
                        }
                        else
                        {
                            _relay.onWriteLog(new WriteLogEventArgs($"{_id}: 代理需要认证\r\n"));
                            this.Close();
                        }
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

            private void Socks5Handshake2SendCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    var bytes = (byte[])((object[])ar.AsyncState)[0];
                    var bytesLen = (int)((object[])ar.AsyncState)[1];
                    var len = _remote.EndSend(ar);
                    if (len == bytesLen - SOCKS5_FIRST_PACKAGE_SIZE)
                    {
                        _remote.BeginReceive(remoteRecvBuffer, 0, RecvSize, 0,
                            new AsyncCallback(Socks5Handshake2RecvCallback), ar.AsyncState);
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

            private void Socks5Handshake2RecvCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    var len = _remote.EndReceive(ar);
                    if (len > 2)
                    {
                        if (remoteRecvBuffer[0] == 0x05 && remoteRecvBuffer[1] == 0x00)
                        {
                            StartPipe();
                        }
                        else
                        {
                            _relay.onWriteLog(new WriteLogEventArgs($"{_id}: 代理连接失败\r\n"));
                            this.Close();
                        }
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
                        var e = new RelayEventArgs(_remote, RelaySockType.Remote, RelaySockAction.Recv, remoteRecvBuffer, 0, bytesRead);
                        _relay.onRelay(e);
                        _local.BeginSend(e.Buffer, e.Offset, e.Length, 0, new AsyncCallback(PipeConnectionSendCallback), e);
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
                        var e = new RelayEventArgs(_local, RelaySockType.Local, RelaySockAction.Recv, connetionRecvBuffer, 0, bytesRead);
                        _relay.onRelay(e);
                        _remote.BeginSend(e.Buffer, e.Offset, e.Length, 0, new AsyncCallback(PipeRemoteSendCallback), e);
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
                    RelayEventArgs buf = (RelayEventArgs)ar.AsyncState;
                    _remote.EndSend(ar);
                    var e = new RelayEventArgs(_remote, RelaySockType.Remote, RelaySockAction.Send, buf.Buffer, buf.Offset, buf.Length);
                    _relay.onRelay(e);
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
                    RelayEventArgs buf = (RelayEventArgs)ar.AsyncState;
                    _local.EndSend(ar);
                    var e = new RelayEventArgs(_local, RelaySockType.Local, RelaySockAction.Send, buf.Buffer, buf.Offset, buf.Length);
                    _relay.onRelay(e);
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
