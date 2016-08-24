using System;
using System.Threading;

namespace TrafficStatistics
{
    public class Traffic
    {
        public long inboundCounter = 0;
        public long outboundCounter = 0;

        public void onInbound(long n)
        {
            Interlocked.Add(ref inboundCounter, n);
        }

        public void onOutbound(long n)
        {
            Interlocked.Add(ref outboundCounter, n);
        }

        public void reset()
        {
            Interlocked.Exchange(ref inboundCounter, 0);
            Interlocked.Exchange(ref outboundCounter, 0);
        }
    }

    public class TrafficLog
    {
        public Traffic raw;
    }

}
