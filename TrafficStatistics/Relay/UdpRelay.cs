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

        private Socket _local;
        private UDPPipe _pipe;

        private EndPoint _localEP;
        private EndPoint _remoteEP;

        public event EventHandler<RelayEventArgs> Inbound;
        public event EventHandler<RelayEventArgs> Outbound;
        public event EventHandler<RelayErrorEventArgs> Error;

        public UDPRelay(EndPoint localEP, EndPoint remoteEP)
        {
            _localEP = localEP;
            _remoteEP = remoteEP;
            this._pipe = new UDPPipe(this, localEP, remoteEP);
        }

        public void Start()
        {
            try
            {
                // Create a TCP/IP socket.
                _local = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _local.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                // Bind the socket to the local endpoint and listen for incoming connections.
                _local.Bind(_localEP);

                // Start an asynchronous socket to listen for connections.
                Console.WriteLine("UDPRelay listen on " + _localEP.ToString());
                localStartReceive();
            }
            catch (SocketException e)
            {
                Stop();
                onError(e);
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

        public void onInbound(long n)
        {
            Inbound?.Invoke(this, new RelayEventArgs(n));
        }

        public void onOutbound(long n)
        {
            Outbound?.Invoke(this, new RelayEventArgs(n));
        }

        public void onError(Exception e)
        {
            Error?.Invoke(this, new RelayErrorEventArgs(e));
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
                onError(e);
            }
        }

        private void localReceiveCallback(IAsyncResult ar)
        {
            State state = (State)ar.AsyncState;
            try
            {
                int bytesRead = _local.EndReceiveFrom(ar, ref state.remoteEP);
                if (_pipe.CreatePipe(state.buffer, bytesRead, _local, state.remoteEP))
                    return;
                // do nothing
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception e)
            {
                onError(e);
            }
            finally
            {
                localStartReceive();
            }
        }

    }
}
