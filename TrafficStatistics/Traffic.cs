using System;
using System.Threading;

namespace TrafficStatistics
{
    public class Traffic
    {
        public long inbound = 0;
        public long outbound = 0;

        public Traffic() { }

        public Traffic(Traffic t)
        {
            inbound = t.inbound;
            outbound = t.outbound;
        }

        public Traffic(Traffic t1, Traffic t2)
        {
            if (t2.inbound > 0 && t1.inbound >= t2.inbound)
                inbound = t1.inbound - t2.inbound;
            if (t2.outbound > 0 && t1.outbound >= t2.outbound)
                outbound = t1.outbound - t2.outbound;
        }

        public void onRecv(long n)
        {
            Interlocked.Add(ref inbound, n);
        }

        public void onSend(long n)
        {
            Interlocked.Add(ref outbound, n);
        }

        public void reset()
        {
            Interlocked.Exchange(ref inbound, 0);
            Interlocked.Exchange(ref outbound, 0);
        }
    }

    public class TrafficLog
    {
        public Traffic total;
        public Traffic speed;

        public TrafficLog()
        {
            total = new Traffic();
            speed = new Traffic();
        }

        public TrafficLog(Traffic total, Traffic speed)
        {
            this.total = total;
            this.speed = speed;
        }
    }

}
