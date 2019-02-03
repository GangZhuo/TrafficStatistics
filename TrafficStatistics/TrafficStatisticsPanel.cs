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
using System.IO;

namespace TrafficStatistics
{
    public partial class TrafficStatisticsPanel : UserControl
    {
        private int trafficLogSize = 60;

        private IRelay relay;
        private Traffic rawTrafficStatistics = new Traffic();
        private LinkedList<TrafficLog> trafficLogList = new LinkedList<TrafficLog>();
        private bool printPayload;
        private int payloadType = -1;


        public TrafficStatisticsPanel()
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

        private void TrafficStatisticsPanel_Load(object sender, EventArgs e)
        {
#if REDIRECT_CONSOLE

            RedirectConsole();

#endif

            ChartComboBox.SelectedIndex = 0;

            TypeComboBox.SelectedIndex = 0;
            PrintPayloadCheckBox.Checked = printPayload;

            timer1.Start();
            timer2.Start();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            timer1.Enabled = timer2.Enabled = false;
            timer1.Stop();
            timer2.Stop();
            Stop();
            base.OnHandleDestroyed(e);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                Start(LeftAddressTextBox.Text, RightTextBox.Text, TypeComboBox.SelectedItem.ToString() == "UDP");
            }
            catch (Exception ex)
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

        private void ChartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            trafficLogSize = (ChartComboBox.SelectedIndex + 1) * 60;
        }

        private void PrintPayloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            printPayload = PrintPayloadCheckBox.Checked;
        }

        private EndPoint ParseEndPoint(string address)
        {
            int index = address.LastIndexOf(':');
            string ipStr = address.Substring(0, index);
            string portStr = address.Substring(index + 1);
            IPAddress ipAddress;
            if (string.IsNullOrEmpty(ipStr))
                ipAddress = IPAddress.Any;
            else if (!IPAddress.TryParse(ipStr, out ipAddress))
                ipAddress = Dns.GetHostEntry(ipStr).AddressList[0];
            IPEndPoint ep = new IPEndPoint(ipAddress, Convert.ToInt32(portStr));
            return ep;
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
            rawTrafficStatistics.onInbound(e.Length);
            if (printPayload)
            {
                if (payloadType != 0)
                {
                    AppendLog($"\n================[Inbound]================\n");
                    payloadType = 0;
                }
                string str = Encoding.UTF8.GetString(e.Buffer, e.Offset, e.Length);
                AppendLog(str);
            }
        }

        private void Relay_Outbound(object sender, RelayEventArgs e)
        {
            rawTrafficStatistics.onOutbound(e.Length);
            if (printPayload)
            {
                if (payloadType != 1)
                {
                    AppendLog($"\n================[Outbound]================\n");
                    payloadType = 1;
                }
                string str = Encoding.UTF8.GetString(e.Buffer, e.Offset, e.Length);
                AppendLog(str);
            }
        }

        private void Relay_Error(object sender, RelayErrorEventArgs e)
        {
            if (e.Error != null)
                AppendLog(e.Error.ToString());
        }

        private void AppendLog(string text)
        {
            if (LogTextBox.InvokeRequired)
            {
                LogTextBox.Invoke(new EventHandler((s, e) =>
                {
                    LogTextBox.AppendText(text);
                    LogTextBox.ScrollToCaret();
                }), this, null);
            }
            else
            {
                LogTextBox.AppendText(text);
                LogTextBox.ScrollToCaret();
            }
        }

        private void InitTrafficHistoricalList()
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
            lock (trafficLogList)
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

#if REDIRECT_CONSOLE

        void RedirectConsole()
        {
            try
            {
                var sw = new ConsoleWriter(this);
                Console.SetOut(sw);
                Console.SetError(sw);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        class ConsoleWriter : TextWriter
        {
            private WeakReference<TrafficStatisticsPanel> _control;

            public override Encoding Encoding { get { return Encoding.UTF8; } }

            public ConsoleWriter(TrafficStatisticsPanel control)
            {
                _control = new WeakReference<TrafficStatisticsPanel>(control);
            }

            public override void WriteLine(string value)
            {
                Write($"{value}\n");
            }

            public override void Write(string value)
            {
                TrafficStatisticsPanel control;
                if (_control.TryGetTarget(out control))
                    control.AppendLog(value);
            }

        }

#endif

    }
}
