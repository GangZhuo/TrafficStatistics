using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficStatistics
{
    public class ItemInfo
    {
        public string Protocol { get; set; }

        public string LocalAddress { get; set; }

        public string RemoteAddress { get; set; }

        public bool PrintPayload { get; set; }

    }
}
