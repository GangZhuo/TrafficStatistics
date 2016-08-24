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
        private const int TrafficHistoricalSize = 80;

        private IRelay relay;
        private Traffic rawTrafficStatistics = new Traffic();
        private LinkedList<TrafficLog> trafficLogList;

        public TrafficStatisticsForm()
        {
            InitializeComponent();
            InitTrafficHistoricalList();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTrafficStatistics();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
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
            if (trafficLogList == null)
                trafficLogList = new LinkedList<TrafficLog>();
            else
                trafficLogList.Clear();
            for (int i = 0; i < TrafficHistoricalSize; i++)
            {
                TrafficLog item = new TrafficLog();
                item.raw = new Traffic
                {
                    inboundCounter = 0,
                    outboundCounter = 0
                };
                trafficLogList.AddLast(item);
            }
        }

        private void UpdateTrafficList()
        {
            TrafficLog current = new TrafficLog();
            current.raw = new Traffic
            {
                inboundCounter = rawTrafficStatistics.inboundCounter,
                outboundCounter = rawTrafficStatistics.outboundCounter
            };
            trafficLogList.AddLast(current);

            if (trafficLogList.Count > TrafficHistoricalSize)
                trafficLogList.RemoveFirst();
        }

        private List<float> rawInboundPoints = new List<float>();
        private List<float> rawOutboundPoints = new List<float>();
        private string[] units = new string[] { "B", "KiB", "MiB", "GiB" };

        private void UpdateTrafficChart()
        {
            TrafficLog previous = null;
            int i = 0;
            long maxSpeed = 0;
            rawInboundPoints.Clear();
            rawOutboundPoints.Clear();
            foreach (TrafficLog item in trafficLogList)
            {
                if (previous == null)
                {
                    rawInboundPoints.Add(item.raw.inboundCounter);
                    rawOutboundPoints.Add(item.raw.outboundCounter);
                }
                else
                {
                    rawInboundPoints.Add(item.raw.inboundCounter - previous.raw.inboundCounter);
                    rawOutboundPoints.Add(item.raw.outboundCounter - previous.raw.outboundCounter);
                }

                maxSpeed = Math.Max(maxSpeed, (long)Math.Max(rawInboundPoints[i], rawOutboundPoints[i]));

                previous = item;
                i++;
            }

            FormattedSize formattedMaxSpeed = new FormattedSize(maxSpeed);

            if (rawInboundPoints.Count > 0)
            {
                i = rawInboundPoints.Count - 1;
                RawInboundSpeed.Text = new FormattedSize((long)rawInboundPoints[i]) + "/s";
                RawOutboundSpeed.Text = new FormattedSize((long)rawOutboundPoints[i]) + "/s";
            }

            for (i = 0; i < rawInboundPoints.Count; i++)
            {
                rawInboundPoints[i] /= formattedMaxSpeed.scale;
                rawOutboundPoints[i] /= formattedMaxSpeed.scale;
            }

            TrafficChart.Series["Inbound"].Points.DataBindY(rawInboundPoints);
            TrafficChart.Series["Outbound"].Points.DataBindY(rawOutboundPoints);
            TrafficChart.Series["Inbound"].ToolTip = "#SERIESNAME #VALY{F2} " + formattedMaxSpeed.unit;
            TrafficChart.Series["Outbound"].ToolTip = "#SERIESNAME #VALY{F2} " + formattedMaxSpeed.unit;
            TrafficChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.##} " + formattedMaxSpeed.unit;

        }

        private void UpdateTrafficStatistics()
        {
            RawInbound.Text = new FormattedSize(rawTrafficStatistics.inboundCounter).ToString();
            RawOutbound.Text = new FormattedSize(rawTrafficStatistics.outboundCounter).ToString();
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
    }
}
