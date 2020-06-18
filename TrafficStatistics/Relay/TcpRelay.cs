using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace TrafficStatistics.Relay
{
    public class TCPRelay : IRelay
    {
        private Socket _socket;
        private TCPPipe _pipe;

        private EndPoint _localEP;
        private EndPoint _remoteEP;
        private EndPoint _socks5EP;
        private bool _useProxy;

        public event EventHandler<RelayEventArgs> Inbound;
        public event EventHandler<RelayEventArgs> Outbound;
        public event EventHandler<RelayErrorEventArgs> Error;
        public event EventHandler<WriteLogEventArgs> WriteLog;

        public TCPRelay(EndPoint localEP, EndPoint remoteEP, EndPoint socks5EP, bool useProxy)
        {
            _localEP = localEP;
            _remoteEP = remoteEP;
            _socks5EP = socks5EP;
            _useProxy = useProxy;
            this._pipe = new TCPPipe(this, localEP, remoteEP, socks5EP, useProxy);
        }

        public void Start()
        {
            try
            {
                // Create a TCP/IP socket.
                _socket = new Socket(_localEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                // Bind the socket to the local endpoint and listen for incoming connections.
                _socket.Bind(_localEP);
                _socket.Listen(1024);
                // Start an asynchronous socket to listen for connections.
                Console.WriteLine("TCPRelay listen on " + _localEP.ToString());
                _socket.BeginAccept(new AsyncCallback(AcceptCallback), _socket);
            }
            catch (SocketException)
            {
                _socket.Close();
                throw;
            }
        }

        public void Stop()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket = null;
            }
        }

        public void onInbound(RelayEventArgs e)
        {
            Inbound?.Invoke(this, e);
        }

        public void onOutbound(RelayEventArgs e)
        {
            Outbound?.Invoke(this, e);
        }

        public void onError(RelayErrorEventArgs e)
        {
            Error?.Invoke(this, e);
        }

        public void onWriteLog(WriteLogEventArgs e)
        {
            WriteLog?.Invoke(this, e);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            try
            {
                Socket conn = listener.EndAccept(ar);
                if (_pipe.CreatePipe(conn))
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
                try
                {
                    listener.BeginAccept( new AsyncCallback(AcceptCallback), listener);
                }
                catch (ObjectDisposedException)
                {
                    // do nothing
                }
                catch (Exception e)
                {
                    onError(new RelayErrorEventArgs(e));
                }
            }
        }
    }
}
