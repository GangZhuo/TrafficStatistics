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
        private Traffic traffic = new Traffic();
        private LinkedList<TrafficLog> logList = new LinkedList<TrafficLog>();
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
                logList.AddLast(new TrafficLog());
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
            lock (logList)
            {
                logList.Clear();
                for (int i = 0; i < trafficLogSize; i++)
                {
                    logList.AddLast(new TrafficLog());
                }
            }
        }

        public void UpdateTrafficList(Traffic traffic)
        {
            long maxSpeedValue = 0;
            inboundPoints.Clear();
            outboundPoints.Clear();

            lock (logList)
            {
                if (traffic != null)
                {
                    this.traffic = traffic;
                    #region Add to trafficLogList
                    TrafficLog previous = logList.Last.Value;
                    TrafficLog current = new TrafficLog(
                        new Traffic(traffic),
                        new Traffic(traffic, previous.total)
                    );
                    logList.AddLast(current);

                    while (logList.Count > trafficLogSize) logList.RemoveFirst();
                    while (logList.Count < trafficLogSize) logList.AddFirst(new TrafficLog());
                    #endregion
                }

                lastLog = logList.Last.Value;
                foreach (TrafficLog item in logList)
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
            lbRecvTotal.Text = new FormattedSize(traffic.inbound).ToString();
            lbSendTotal.Text = new FormattedSize(traffic.outbound).ToString();

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
