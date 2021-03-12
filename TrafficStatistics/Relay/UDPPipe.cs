using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace TrafficStatistics.Relay
{
    public class UDPPipe
    {
        private IRelay _relay;
        private EndPoint _localEP;
        private EndPoint _remoteEP;
        private EndPoint _socks5EP;
        private bool _useProxy;

        Hashtable _handlers = Hashtable.Synchronized(new Hashtable());

        System.Timers.Timer _timer = new System.Timers.Timer(10000);

        public UDPPipe(IRelay relay, EndPoint localEP, EndPoint remoteEP, EndPoint socks5EP, bool useProxy)
        {
            _relay = relay;
            _localEP = localEP;
            _remoteEP = remoteEP;
            _socks5EP = socks5EP;
            _useProxy = useProxy;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        ~UDPPipe()
        {
            _timer.Stop();
            _handlers.Clear();
        }

        public bool CreatePipe(byte[] firstPacket, int length, Socket fromSocket, EndPoint fromEP)
        {
            Handler handler = getHandler(fromEP, fromSocket, _socks5EP, _useProxy);
            handler.Handle(firstPacket, length);
            return true;
        }

        Handler getHandler(EndPoint fromEP, Socket fromSocket, EndPoint socks5EP, bool useProxy)
        {
            string key = fromEP.ToString();
            lock(this)
            {
                if (_handlers.ContainsKey(key))
                {
                    return (Handler)_handlers[key];
                }
                Handler handler = new Handler(_relay);
                _handlers.Add(key, handler);
                handler._local = fromSocket;
                handler._localEP = fromEP;
                handler._remoteEP = _remoteEP;
                handler._socks5EP = socks5EP;
                handler._useProxy = useProxy;
                handler.OnClose += handler_OnClose;
                handler.Start();
                return handler;
            }
        }

        private void handler_OnClose(object sender, EventArgs e)
        {
            Handler handler = (Handler)sender;
            string key = handler._localEP.ToString();
            lock (this)
            {
                if (_handlers.ContainsKey(key))
                {
                    _handlers.Remove(key);
                }
            }
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _timer.Stop();
                List<Handler> keys = new List<Handler>(_handlers.Count);
                lock (this)
                {
                    foreach (string key in _handlers.Keys)
                    {
                        Handler handler = (Handler)_handlers[key];
                        if (handler.IsExpire())
                        {
                            keys.Add(handler);
                        }
                    }
                    foreach (Handler handler in keys)
                    {
                        string key = handler._localEP.ToString();
                        handler.Close(false);
                        _handlers.Remove(key);
                    }
                }
            }
            catch (Exception ex)
            {
                _relay.onError(new RelayErrorEventArgs(ex));
            }
            finally
            {
                _timer.Start();
            }
        }

        class Handler
        {
            public event EventHandler OnClose;

            private DateTime _expires;

            public Socket _local;
            private IRelay _relay;
            public EndPoint _localEP;
            public EndPoint _remoteEP;
            public Socket _remote;
            public EndPoint _socks5EP;
            public bool _useProxy;

            private bool _closed = false;
            public const int RecvSize = 16384;
            // remote receive buffer
            private byte[] remoteRecvBuffer = new byte[RecvSize];

            private LinkedList<byte[]> _packages = new LinkedList<byte[]>();
            private bool _connected = false;
            private bool _sending = false;

            public Handler(IRelay relay)
            {
                _relay = relay;
            }

            public bool IsExpire()
            {
                lock(this)
                {
                    return _expires <= DateTime.Now;
                }
            }

            public void Start()
            {
                try
                {
                    _remote = new Socket(_remoteEP.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                    _remote.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.NoDelay, true);
                    _remote.BeginConnect(_remoteEP, new AsyncCallback(remoteConnectCallback), null);
                    Delay();
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            public void Handle(byte[] buffer, int length)
            {
                if (_closed) return;
                try
                {
                    if (length > 0)
                    {
                        lock (_packages)
                        {
                            byte[] bytes = new byte[length];
                            Buffer.BlockCopy(buffer, 0, bytes, 0, length);
                            _packages.AddLast(bytes);
                        }
                        StartSend();
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

            private void remoteConnectCallback(IAsyncResult ar)
            {
                if (_closed) return;
                try
                {
                    _remote.EndConnect(ar);
                    lock (_packages)
                        _connected = true;
                    StartPipe();
                    StartSend();
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void StartPipe()
            {
                if (_closed) return;
                try
                {
                    _remote.BeginReceive(this.remoteRecvBuffer, 0, RecvSize, 0,
                        new AsyncCallback(remoteReceiveCallback), null);
                    Delay();
                    StartSend();
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void StartSend()
            {
                if (_closed) return;
                try
                {
                    lock (_packages)
                    {
                        if (_sending || !_connected)
                            return;
                        if (_packages.Count > 0)
                        {
                            _sending = true;
                            byte[] bytes = _packages.First.Value;
                            _packages.RemoveFirst();
                            _remote.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(remoteSendCallback), bytes);
                            Delay();
                        }
                    }
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void remoteSendCallback(IAsyncResult ar)
            {
                if (_closed) return;
                try
                {
                    byte[] bytes = (byte[])ar.AsyncState;
                    _remote.EndSend(ar);
                    var e = new RelayEventArgs(_remote, RelaySockType.Remote, RelaySockAction.Send, _remoteEP, bytes, 0, bytes.Length);
                    _relay.onRelay(e);
                    lock (_packages)
                        _sending = false;
                    StartSend();
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void remoteReceiveCallback(IAsyncResult ar)
            {
                if (_closed) return;
                try
                {
                    int bytesRead = _remote.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        var e = new RelayEventArgs(_remote, RelaySockType.Remote, RelaySockAction.Recv, _remoteEP, remoteRecvBuffer, 0, bytesRead);
                        _relay.onRelay(e);
                        _local.BeginSendTo(e.Buffer, 0, e.Length, 0, _localEP, new AsyncCallback(localSendCallback), e);
                        Delay();
                    }
                    else
                    {
                        this.Close();
                    }
                    Delay();
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void localSendCallback(IAsyncResult ar)
            {
                if (_closed) return;
                try
                {
                    RelayEventArgs buf = (RelayEventArgs)ar.AsyncState;
                    _local.EndSendTo(ar);
                    var e = new RelayEventArgs(_local, RelaySockType.Local, RelaySockAction.Send, _localEP, buf.Buffer, buf.Offset, buf.Length);
                    _relay.onRelay(e);
                    _remote.BeginReceive(this.remoteRecvBuffer, 0, RecvSize, 0,
                        new AsyncCallback(remoteReceiveCallback), null);
                    Delay();
                }
                catch (Exception e)
                {
                    _relay.onError(new RelayErrorEventArgs(e));
                    this.Close();
                }
            }

            private void Delay()
            {
                lock (this)
                {
                    _expires = DateTime.Now.AddSeconds(120);
                }
            }

            public void Close(bool reportClose = true)
            {
                if (_closed) return;
                _closed = true;
                if (_remote != null)
                {
                    try
                    {
                        _remote.Shutdown(SocketShutdown.Both);
                        _remote.Close();
                        _remote = null;
                        remoteRecvBuffer = null;
                        _packages.Clear();
                        _packages = null;
                    }
                    catch (SocketException e)
                    {
                        _relay.onError(new RelayErrorEventArgs(e));
                    }
                }
                if (reportClose && OnClose != null)
                {
                    OnClose(this, new EventArgs());
                    OnClose = null;
                }
            }
        }
    }
}
