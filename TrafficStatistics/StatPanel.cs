using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficStatistics
{
    public partial class StatPanel : UserControl
    {
        private LinkedList<TrafficLog> trafficLogList = new LinkedList<TrafficLog>();
        private List<float> inboundPoints = new List<float>();
        private List<float> outboundPoints = new List<float>();
        private FormattedSize maxSpeed;
        private TrafficLog lastLog;
        private int trafficLogSize = 60;

        public StatPanel()
        {
            InitializeComponent();

            for (int i = 0; i < trafficLogSize; i++)
            {
                trafficLogList.AddLast(new TrafficLog());
            }
        }

        private void StatPanel_Load(object sender, EventArgs e)
        {
            UpdateTrafficList(null);
        }

        public void SetXSize(int x)
        {
            trafficLogSize = x;
        }

        public void InitTrafficHistoricalList()
        {
            lock (trafficLogList)
            {
                trafficLogList.Clear();
                for (int i = 0; i < trafficLogSize; i++)
                {
                    trafficLogList.AddLast(new TrafficLog());
                }
            }
        }

        public void UpdateTrafficList(Traffic traffic)
        {
            long maxSpeedValue = 0;
            inboundPoints.Clear();
            outboundPoints.Clear();

            lock (trafficLogList)
            {
                if (traffic != null)
                {
                    #region Add to trafficLogList
                    TrafficLog previous = trafficLogList.Last.Value;
                    TrafficLog current = new TrafficLog(
                        new Traffic(traffic),
                        new Traffic(traffic, previous.total)
                    );
                    trafficLogList.AddLast(current);

                    while (trafficLogList.Count > trafficLogSize) trafficLogList.RemoveFirst();
                    while (trafficLogList.Count < trafficLogSize) trafficLogList.AddFirst(new TrafficLog());
                    #endregion
                }

                lastLog = trafficLogList.Last.Value;
                foreach (TrafficLog item in trafficLogList)
                {
                    inboundPoints.Add(item.speed.inbound);
                    outboundPoints.Add(item.speed.outbound);

                    maxSpeedValue = Math.Max(maxSpeedValue,
                            Math.Max(item.speed.inbound, item.speed.outbound)
                    );
                }
            }

            maxSpeed = new FormattedSize(maxSpeedValue);

            for (int i = 0; i < inboundPoints.Count; i++)
            {
                inboundPoints[i] /= maxSpeed.scale;
                outboundPoints[i] /= maxSpeed.scale;
            }

            if (TrafficChart.InvokeRequired)
            {
                TrafficChart.Invoke(new Action(UpdateTrafficChart));
            }
            else
            {
                UpdateTrafficChart();
            }
        }

        private void UpdateTrafficChart()
        {
            TrafficChart.Series["Inbound"].LegendText = "Inbound (" + new FormattedSize(lastLog.speed.inbound) + "/s)";
            TrafficChart.Series["Outbound"].LegendText = "Outbound (" + new FormattedSize(lastLog.speed.outbound) + "/s)";

            TrafficChart.Series["Inbound"].Points.DataBindY(inboundPoints);
            TrafficChart.Series["Outbound"].Points.DataBindY(outboundPoints);

            TrafficChart.Series["Inbound"].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit + "/s";
            TrafficChart.Series["Outbound"].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit + "/s";

            TrafficChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.##} " + maxSpeed.unit + "/s";
        }
    }
}
