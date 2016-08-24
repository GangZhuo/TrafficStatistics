using System;

namespace TrafficStatistics.Relay
{
    public interface IRelay
    {
        event EventHandler<RelayEventArgs> Inbound;
        event EventHandler<RelayEventArgs> Outbound;
        event EventHandler<RelayErrorEventArgs> Error;

        void Start();
        void Stop();

        void onInbound(long n);
        void onOutbound(long n);
        void onError(Exception e);
    }

    public class RelayEventArgs : EventArgs
    {
        public long Value { get; private set; }

        public RelayEventArgs(long value)
        {
            Value = value;
        }
    }

    public class RelayErrorEventArgs : EventArgs
    {
        public Exception Error { get; private set; }

        public RelayErrorEventArgs(Exception error)
        {
            Error = error;
        }
    }
}