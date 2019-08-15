using System;

namespace TrafficStatistics.Relay
{
    public interface IRelay
    {
        event EventHandler<RelayEventArgs> Inbound;
        event EventHandler<RelayEventArgs> Outbound;
        event EventHandler<RelayErrorEventArgs> Error;
        event EventHandler<WriteLogEventArgs> WriteLog;

        void Start();
        void Stop();

        void onInbound(RelayEventArgs e);
        void onOutbound(RelayEventArgs e);
        void onError(RelayErrorEventArgs e);
        void onWriteLog(WriteLogEventArgs e);
    }

    public class RelayEventArgs : EventArgs
    {
        public byte[] Buffer { get; private set; }
        public int Offset { get; private set; }
        public int Length { get; private set; }

        public RelayEventArgs(byte[] buffer, int offset, int length)
        {
            Buffer = buffer;
            Offset = offset;
            Length = length;
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

    public class WriteLogEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public WriteLogEventArgs(string msg)
        {
            Message = msg;
        }
    }
}