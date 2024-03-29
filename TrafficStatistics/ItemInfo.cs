﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficStatistics
{
    public class ItemInfo
    {
        public string Description { get; set; }

        public string Protocol { get; set; }

        public string LocalAddress { get; set; }

        public string RemoteAddress { get; set; }

        public bool PrintLocalPayload { get; set; }

        public bool PrintRemotePayload { get; set; }

        public bool PrintPayloadAsText { get; set; }

        public string Socks5Address { get; set; }

        public bool UseSocks5Proxy { get; set; }

        public int ChartRange { get; set; }
    }
}
