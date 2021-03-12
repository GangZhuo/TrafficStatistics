using System;
using System.Net;
using System.Net.Sockets;

namespace TrafficStatistics.Relay
{
    public class UDPRelay : IRelay
    {
        public class State
        {
            public byte[] buffer;
            public EndPoint remoteEP;

            public State()
            {
                buffer = new byte[4096];
                remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
            }
        }

        private const int SIP_UDP_CONNRESET = -1744830452;

        private Socket _local;
        private UDPPipe _pipe;

        private EndPoint _localEP;
        private EndPoint _remoteEP;
        private EndPoint _socks5EP;
        private bool _useProxy;

        public event EventHandler<RelayEventArgs> Relay;
        public event EventHandler<RelayErrorEventArgs> Error;
        public event EventHandler<WriteLogEventArgs> WriteLog;

        public UDPRelay(EndPoint localEP, EndPoint remoteEP, EndPoint socks5EP, bool useProxy)
        {
            _localEP = localEP;
            _remoteEP = remoteEP;
            _socks5EP = socks5EP;
            _useProxy = useProxy;
            this._pipe = new UDPPipe(this, localEP, remoteEP, socks5EP, useProxy);
        }

        public void Start()
        {
            try
            {
                // Create a TCP/IP socket.
                _local = new Socket(_localEP.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                _local.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                // Fix WinSock library bug, See https://support.microsoft.com/en-us/kb/263823
                _local.IOControl(SIP_UDP_CONNRESET, new byte[] { 0, 0, 0, 0 }, null);
                // Bind the socket to the local endpoint and listen for incoming connections.
                _local.Bind(_localEP);

                // Start an asynchronous socket to listen for connections.
                Console.WriteLine("UDPRelay listen on " + _localEP.ToString());
                localStartReceive();
            }
            catch (SocketException e)
            {
                Stop();
                onError(new RelayErrorEventArgs(e));
            }
        }

        public void Stop()
        {
            if (_local != null)
            {
                _local.Close();
                _local = null;
            }
        }

        public void onRelay(RelayEventArgs e)
        {
            Relay?.Invoke(this, e);
        }

        public void onError(RelayErrorEventArgs e)
        {
            Error?.Invoke(this, e);
        }

        public void onWriteLog(WriteLogEventArgs e)
        {
            WriteLog?.Invoke(this, e);
        }

        private void localStartReceive()
        {
            try
            {
                State state = new State();
                _local.BeginReceiveFrom(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                    ref state.remoteEP, new AsyncCallback(localReceiveCallback), state);
            }
            catch (Exception e)
            {
                onError(new RelayErrorEventArgs(e));
            }
        }

        private void localReceiveCallback(IAsyncResult ar)
        {
            State state = (State)ar.AsyncState;
            try
            {
                int bytesRead = _local.EndReceiveFrom(ar, ref state.remoteEP);
                var e = new RelayEventArgs(_local, RelaySockType.Local, RelaySockAction.Recv, state.remoteEP, state.buffer, 0, bytesRead);
                onRelay(e);
                if (_pipe.CreatePipe(state.buffer, bytesRead, _local, state.remoteEP))
                    return;
                // do nothing
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception e)
            {
                onError(new RelayErrorEventArgs(e));
            }
            finally
            {
                localStartReceive();
            }
        }

    }
}
