namespace TrafficStatistics
{
    partial class TrafficStatisticsPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.RightTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LeftAddressTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.RawGroupBox = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TrafficChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RawOutboundSpeed = new System.Windows.Forms.Label();
            this.RawInboundSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RawOutbound = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RawInbound = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PrintPayloadCheckBox = new System.Windows.Forms.CheckBox();
            this.ChartComboBox = new System.Windows.Forms.ComboBox();
            this.CleanLogsButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.txSocks5 = new System.Windows.Forms.TextBox();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RawGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(260, 114);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(110, 28);
            this.StopButton.TabIndex = 5;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(260, 77);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(110, 28);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // RightTextBox
            // 
            this.RightTextBox.Location = new System.Drawing.Point(71, 73);
            this.RightTextBox.MaxLength = 200;
            this.RightTextBox.Name = "RightTextBox";
            this.RightTextBox.Size = new System.Drawing.Size(164, 21);
            this.RightTextBox.TabIndex = 2;
            this.RightTextBox.Text = "127.0.0.1:5211";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Remote:";
            // 
            // LeftAddressTextBox
            // 
            this.LeftAddressTextBox.Location = new System.Drawing.Point(71, 47);
            this.LeftAddressTextBox.MaxLength = 200;
            this.LeftAddressTextBox.Name = "LeftAddressTextBox";
            this.LeftAddressTextBox.Size = new System.Drawing.Size(164, 21);
            this.LeftAddressTextBox.TabIndex = 1;
            this.LeftAddressTextBox.Text = "127.0.0.1:5210";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Local:";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.TypeComboBox.Location = new System.Drawing.Point(71, 20);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(81, 20);
            this.TypeComboBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type:";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(376, 77);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(110, 28);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset Statistics";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // RawGroupBox
            // 
            this.RawGroupBox.Controls.Add(this.panel2);
            this.RawGroupBox.Controls.Add(this.panel1);
            this.RawGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawGroupBox.Location = new System.Drawing.Point(0, 0);
            this.RawGroupBox.Name = "RawGroupBox";
            this.RawGroupBox.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.RawGroupBox.Size = new System.Drawing.Size(571, 156);
            this.RawGroupBox.TabIndex = 0;
            this.RawGroupBox.TabStop = false;
            this.RawGroupBox.Text = "Statistics";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(551, 58);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TrafficChart);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(551, 58);
            this.panel3.TabIndex = 1;
            // 
            // TrafficChart
            // 
            this.TrafficChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.Interval = 3D;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX2.MajorTickMark.Enabled = false;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea2.AxisY.LabelStyle.Interval = 0D;
            chartArea2.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY2.MajorTickMark.Enabled = false;
            chartArea2.AxisY2.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            this.TrafficChart.ChartAreas.Add(chartArea2);
            this.TrafficChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Font = new System.Drawing.Font("Consolas", 8F);
            legend2.IsTextAutoFit = false;
            legend2.MaximumAutoSize = 80F;
            legend2.Name = "Legend1";
            this.TrafficChart.Legends.Add(legend2);
            this.TrafficChart.Location = new System.Drawing.Point(0, 0);
            this.TrafficChart.Name = "TrafficChart";
            this.TrafficChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Font = new System.Drawing.Font("Consolas", 8F);
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Inbound";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Font = new System.Drawing.Font("Consolas", 8F);
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "Outbound";
            this.TrafficChart.Series.Add(series3);
            this.TrafficChart.Series.Add(series4);
            this.TrafficChart.Size = new System.Drawing.Size(551, 58);
            this.TrafficChart.TabIndex = 0;
            this.TrafficChart.Text = "Traffic Chart";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RawOutboundSpeed);
            this.panel1.Controls.Add(this.RawInboundSpeed);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RawOutbound);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.RawInbound);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 66);
            this.panel1.TabIndex = 4;
            // 
            // RawOutboundSpeed
            // 
            this.RawOutboundSpeed.AutoSize = true;
            this.RawOutboundSpeed.Location = new System.Drawing.Point(369, 37);
            this.RawOutboundSpeed.Name = "RawOutboundSpeed";
            this.RawOutboundSpeed.Size = new System.Drawing.Size(77, 12);
            this.RawOutboundSpeed.TabIndex = 7;
            this.RawOutboundSpeed.Text = "Raw Outbound";
            // 
            // RawInboundSpeed
            // 
            this.RawInboundSpeed.AutoSize = true;
            this.RawInboundSpeed.Location = new System.Drawing.Point(98, 37);
            this.RawInboundSpeed.Name = "RawInboundSpeed";
            this.RawInboundSpeed.Size = new System.Drawing.Size(107, 12);
            this.RawInboundSpeed.TabIndex = 6;
            this.RawInboundSpeed.Text = "Raw Inbound Speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inbound:";
            // 
            // RawOutbound
            // 
            this.RawOutbound.AutoSize = true;
            this.RawOutbound.Location = new System.Drawing.Point(369, 13);
            this.RawOutbound.Name = "RawOutbound";
            this.RawOutbound.Size = new System.Drawing.Size(77, 12);
            this.RawOutbound.TabIndex = 3;
            this.RawOutbound.Text = "Raw Outbound";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Outbound:";
            // 
            // RawInbound
            // 
            this.RawInbound.AutoSize = true;
            this.RawInbound.Location = new System.Drawing.Point(98, 13);
            this.RawInbound.Name = "RawInbound";
            this.RawInbound.Size = new System.Drawing.Size(71, 12);
            this.RawInbound.TabIndex = 2;
            this.RawInbound.Text = "Raw Inbound";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkUseProxy);
            this.groupBox1.Controls.Add(this.txSocks5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.PrintPayloadCheckBox);
            this.groupBox1.Controls.Add(this.ChartComboBox);
            this.groupBox1.Controls.Add(this.CleanLogsButton);
            this.groupBox1.Controls.Add(this.ResetButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TypeComboBox);
            this.groupBox1.Controls.Add(this.StopButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.StartButton);
            this.groupBox1.Controls.Add(this.LeftAddressTextBox);
            this.groupBox1.Controls.Add(this.RightTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 150);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Panel";
            // 
            // PrintPayloadCheckBox
            // 
            this.PrintPayloadCheckBox.AutoSize = true;
            this.PrintPayloadCheckBox.Location = new System.Drawing.Point(71, 101);
            this.PrintPayloadCheckBox.Name = "PrintPayloadCheckBox";
            this.PrintPayloadCheckBox.Size = new System.Drawing.Size(102, 16);
            this.PrintPayloadCheckBox.TabIndex = 8;
            this.PrintPayloadCheckBox.Text = "Print payload";
            this.PrintPayloadCheckBox.UseVisualStyleBackColor = true;
            this.PrintPayloadCheckBox.CheckedChanged += new System.EventHandler(this.PrintPayloadCheckBox_CheckedChanged);
            // 
            // ChartComboBox
            // 
            this.ChartComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChartComboBox.FormattingEnabled = true;
            this.ChartComboBox.Location = new System.Drawing.Point(71, 122);
            this.ChartComboBox.Name = "ChartComboBox";
            this.ChartComboBox.Size = new System.Drawing.Size(164, 20);
            this.ChartComboBox.TabIndex = 7;
            this.ChartComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartComboBox_SelectedIndexChanged);
            // 
            // CleanLogsButton
            // 
            this.CleanLogsButton.Location = new System.Drawing.Point(376, 114);
            this.CleanLogsButton.Name = "CleanLogsButton";
            this.CleanLogsButton.Size = new System.Drawing.Size(110, 28);
            this.CleanLogsButton.TabIndex = 6;
            this.CleanLogsButton.Text = "Clean Logs";
            this.CleanLogsButton.UseVisualStyleBackColor = true;
            this.CleanLogsButton.Click += new System.EventHandler(this.CleanLogsButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Chart:";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LogTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 155);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.Black;
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogTextBox.ForeColor = System.Drawing.Color.White;
            this.LogTextBox.Location = new System.Drawing.Point(3, 17);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(565, 135);
            this.LogTextBox.TabIndex = 0;
            this.LogTextBox.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(6, 156);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.RawGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(571, 315);
            this.splitContainer1.SplitterDistance = 156;
            this.splitContainer1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Socks5:";
            // 
            // txSocks5
            // 
            this.txSocks5.Location = new System.Drawing.Point(313, 19);
            this.txSocks5.Name = "txSocks5";
            this.txSocks5.Size = new System.Drawing.Size(173, 21);
            this.txSocks5.TabIndex = 10;
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.Location = new System.Drawing.Point(313, 49);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(78, 16);
            this.chkUseProxy.TabIndex = 11;
            this.chkUseProxy.Text = "Use Proxy";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(397, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "(Only for TCP)";
            // 
            // TrafficStatisticsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "TrafficStatisticsPanel";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(583, 477);
            this.Load += new System.EventHandler(this.TrafficStatisticsPanel_Load);
            this.RawGroupBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrafficChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox RawGroupBox;
        private System.Windows.Forms.Label RawOutbound;
        private System.Windows.Forms.Label RawInbound;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RightTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox LeftAddressTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart TrafficChart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label RawOutboundSpeed;
        private System.Windows.Forms.Label RawInboundSpeed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button CleanLogsButton;
        private System.Windows.Forms.ComboBox ChartComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox PrintPayloadCheckBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txSocks5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.Label label8;
    }
}
