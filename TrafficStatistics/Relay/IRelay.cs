using System;
using System.Net;
using System.Net.Sockets;

namespace TrafficStatistics.Relay
{
    public interface IRelay
    {
        event EventHandler<RelayEventArgs> Relay;
        event EventHandler<RelayErrorEventArgs> Error;
        event EventHandler<WriteLogEventArgs> WriteLog;

        void Start();
        void Stop();

        void onRelay(RelayEventArgs e);
        void onError(RelayErrorEventArgs e);
        void onWriteLog(WriteLogEventArgs e);
    }

    public enum RelaySockType
    {
        Local,
        Remote
    }

    public enum RelaySockAction
    {
        Recv,
        Send
    }

    public class RelayEventArgs : EventArgs
    {
        public Socket Sock { get; private set; }
        public RelaySockType SockType { get; private set; }
        public RelaySockAction SockAction { get; private set; }
        /// <summary>
        /// 接收来源地址/发送目标地址
        /// </summary>
        public EndPoint EndPoint { get; private set; }
        public byte[] Buffer { get; private set; }
        public int Offset { get; private set; }
        public int Length { get; private set; }

        public RelayEventArgs(Socket sock, RelaySockType sockType, RelaySockAction sockAction, byte[] buffer, int offset, int length)
        {
            Sock = sock;
            SockType = sockType;
            SockAction = sockAction;
            Buffer = buffer;
            Offset = offset;
            Length = length;
        }

        public RelayEventArgs(Socket sock, RelaySockType sockType, RelaySockAction sockAction, EndPoint ep, byte[] buffer, int offset, int length)
            : this(sock, sockType, sockAction, buffer, offset, length)
        {
            EndPoint = ep;
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