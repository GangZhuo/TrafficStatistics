using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficStatistics.Relay;
using System.Net;

namespace TrafficStatistics
{
    public partial class TrafficStatisticsForm : Form
    {
        private int trafficLogSize = 60;

        private IRelay relay;
        private Traffic rawTrafficStatistics = new Traffic();
        private LinkedList<TrafficLog> trafficLogList = new LinkedList<TrafficLog>();

        public TrafficStatisticsForm()
        {
            InitializeComponent();

            string[] items = new string[30];
            for (int i = 0; i < 30; i++)
            {
                items[i] = $"Display data for last {i + 1} minutes";
            }
            ChartComboBox.Items.AddRange(items);

            InitTrafficHistoricalList();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            ChartComboBox.SelectedIndex = 0;

            TopMostheckBox.Checked = TopMost;
            TypeComboBox.SelectedIndex = 0;

            timer1.Start();
            timer2.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            timer1.Enabled = timer2.Enabled = false;
            timer1.Stop();
            timer2.Stop();
            Stop();
            base.OnClosing(e);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                Start(LeftAddressTextBox.Text, RightTextBox.Text, TypeComboBox.SelectedItem.ToString() == "UDP");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TopMostheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TopMostheckBox.Checked;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            rawTrafficStatistics.reset();
            InitTrafficHistoricalList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTrafficStatistics();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                timer2.Stop();
                UpdateTrafficList();
                if (TrafficChart.InvokeRequired)
                {
                    TrafficChart.Invoke(new EventHandler((sender2, e2) =>
                    {
                        UpdateTrafficChart();
                    }), sender, e);
                }
                else
                {
                    UpdateTrafficChart();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            finally
            {
                timer2.Start();
            }
        }

        private void CleanLogsButton_Click(object sender, EventArgs e)
        {
            LogTextBox.Text = "";
        }

        private EndPoint ParseEndPoint(string s)
        {
            string[] ss = s.Split(':');
            return new IPEndPoint(IPAddress.Parse(ss[0]), Convert.ToInt32(ss[1]));
        }

        private void Start(string leftAddr, string rightAddr, bool udp)
        {
            EndPoint left = ParseEndPoint(leftAddr);
            EndPoint right = ParseEndPoint(rightAddr);
            relay = udp ? (IRelay)new UDPRelay(left, right) : (IRelay)new TCPRelay(left, right);
            relay.Inbound += Relay_Inbound;
            relay.Outbound += Relay_Outbound;
            relay.Error += Relay_Error;
            relay.Start();

            TypeComboBox.Enabled = false;
            LeftAddressTextBox.ReadOnly = true;
            RightTextBox.ReadOnly = true;
            StartButton.Enabled = false;
            StopButton.Enabled = true;

            AppendLog($"Start [{(udp ? "UDP" : "TCP")}] local: {left}, remote: {right}\n");
        }

        private void Stop()
        {
            if (relay != null)
            {
                relay.Stop();
                relay = null;
            }

            TypeComboBox.Enabled = true;
            LeftAddressTextBox.ReadOnly = false;
            RightTextBox.ReadOnly = false;
            StartButton.Enabled = true;
            StopButton.Enabled = false;

            AppendLog($"Stop\n");
        }

        private void Relay_Inbound(object sender, RelayEventArgs e)
        {
            rawTrafficStatistics.onInbound(e.Value);
        }

        private void Relay_Outbound(object sender, RelayEventArgs e)
        {
            rawTrafficStatistics.onOutbound(e.Value);
        }

        private void Relay_Error(object sender, RelayErrorEventArgs e)
        {
            if (e.Error != null)
                AppendLog(e.Error.ToString());
        }

        private void AppendLog(string line)
        {
            if (LogTextBox.InvokeRequired)
            {
                LogTextBox.Invoke(new EventHandler((s, e) => {
                    LogTextBox.AppendText(line);
                    LogTextBox.ScrollToCaret();
                }), this, null);
            }
            else
            {
                LogTextBox.AppendText(line);
                LogTextBox.ScrollToCaret();
            }
        }

        private void InitTrafficHistoricalList()
        {
            lock(trafficLogList)
            {
                trafficLogList.Clear();
                for (int i = 0; i < trafficLogSize; i++)
                {
                    trafficLogList.AddLast(new TrafficLog());
                }
            }
        }

        private void UpdateTrafficList()
        {
            lock (trafficLogList)
            {
                TrafficLog previous = trafficLogList.Last.Value;
                TrafficLog current = new TrafficLog(
                    new Traffic(rawTrafficStatistics),
                    new Traffic(rawTrafficStatistics, previous.raw)
                );
                trafficLogList.AddLast(current);

                while (trafficLogList.Count > trafficLogSize) trafficLogList.RemoveFirst();
                while (trafficLogList.Count < trafficLogSize) trafficLogList.AddFirst(new TrafficLog());
            }
        }

        private List<float> rawInboundPoints = new List<float>();
        private List<float> rawOutboundPoints = new List<float>();
        private string[] units = new string[] { "B", "KiB", "MiB", "GiB" };

        private void UpdateTrafficChart()
        {
            TrafficLog last;
            long maxSpeedValue = 0;
            rawInboundPoints.Clear();
            rawOutboundPoints.Clear();
            lock(trafficLogList)
            {
                last = trafficLogList.Last.Value;
                foreach (TrafficLog item in trafficLogList)
                {
                    rawInboundPoints.Add(item.rawSpeed.inbound);
                    rawOutboundPoints.Add(item.rawSpeed.outbound);

                    maxSpeedValue = Math.Max(maxSpeedValue,
                            Math.Max(item.rawSpeed.inbound, item.rawSpeed.outbound)
                    );
                }
            }

            FormattedSize maxSpeed = new FormattedSize(maxSpeedValue);
            RawInboundSpeed.Text = new FormattedSize(last.rawSpeed.inbound) + "/s";
            RawOutboundSpeed.Text = new FormattedSize(last.rawSpeed.outbound) + "/s";

            for (int i = 0; i < rawInboundPoints.Count; i++)
            {
                rawInboundPoints[i] /= maxSpeed.scale;
                rawOutboundPoints[i] /= maxSpeed.scale;
            }

            TrafficChart.Series["Inbound"].Points.DataBindY(rawInboundPoints);
            TrafficChart.Series["Outbound"].Points.DataBindY(rawOutboundPoints);
            TrafficChart.Series["Inbound"].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit + "/s";
            TrafficChart.Series["Outbound"].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit + "/s";
            TrafficChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.##} " + maxSpeed.unit + "/s";

        }

        private void UpdateTrafficStatistics()
        {
            RawInbound.Text = new FormattedSize(rawTrafficStatistics.inbound).ToString();
            RawOutbound.Text = new FormattedSize(rawTrafficStatistics.outbound).ToString();
        }


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

        private void ChartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            trafficLogSize = (ChartComboBox.SelectedIndex + 1) * 60;
        }
    }
}
