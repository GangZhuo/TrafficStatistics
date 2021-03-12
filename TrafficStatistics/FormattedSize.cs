using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficStatistics
{
    class FormattedSize
    {
        public long rawValue;

        public long scale;
        public float value;
        public string unit;

        public FormattedSize() { }

        public FormattedSize(long n)
        {
            FormatSize(n);
        }

        public void FormatSize(long n)
        {
            rawValue = n;
            long scale = 1;
            float f = n;
            string unit = "B";
            if (f > 1024)
            {
                f = f / 1024;
                scale <<= 10;
                unit = "KiB";
            }
            if (f > 1024)
            {
                f = f / 1024;
                scale <<= 10;
                unit = "MiB";
            }
            if (f > 1024)
            {
                f = f / 1024;
                scale <<= 10;
                unit = "GiB";
            }
            if (f > 1024)
            {
                f = f / 1024;
                scale <<= 10;
                unit = "TiB";
            }
            this.scale = scale;
            this.value = f;
            this.unit = unit;
        }

        public override string ToString()
        {
            return value.ToString("F2") + " " + unit;
        }

    }
}
