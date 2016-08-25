namespace TrafficStatistics
{
    partial class TrafficStatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrafficStatisticsForm));
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.RightTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LeftAddressTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TopMostheckBox = new System.Windows.Forms.CheckBox();
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
            this.CleanLogsButton = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.ChartComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RawGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(260, 78);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(110, 42);
            this.StopButton.TabIndex = 5;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(260, 27);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(110, 42);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // RightTextBox
            // 
            this.RightTextBox.Location = new System.Drawing.Point(71, 79);
            this.RightTextBox.MaxLength = 200;
            this.RightTextBox.Name = "RightTextBox";
            this.RightTextBox.Size = new System.Drawing.Size(164, 20);
            this.RightTextBox.TabIndex = 2;
            this.RightTextBox.Text = "127.0.0.1:5211";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Right:";
            // 
            // LeftAddressTextBox
            // 
            this.LeftAddressTextBox.Location = new System.Drawing.Point(71, 51);
            this.LeftAddressTextBox.MaxLength = 200;
            this.LeftAddressTextBox.Name = "LeftAddressTextBox";
            this.LeftAddressTextBox.Size = new System.Drawing.Size(164, 20);
            this.LeftAddressTextBox.TabIndex = 1;
            this.LeftAddressTextBox.Text = "127.0.0.1:5210";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Left:";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.TypeComboBox.Location = new System.Drawing.Point(71, 22);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(81, 21);
            this.TypeComboBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type:";
            // 
            // TopMostheckBox
            // 
            this.TopMostheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TopMostheckBox.AutoSize = true;
            this.TopMostheckBox.Location = new System.Drawing.Point(71, 107);
            this.TopMostheckBox.Name = "TopMostheckBox";
            this.TopMostheckBox.Size = new System.Drawing.Size(70, 17);
            this.TopMostheckBox.TabIndex = 3;
            this.TopMostheckBox.Text = "Top most";
            this.TopMostheckBox.UseVisualStyleBackColor = true;
            this.TopMostheckBox.CheckedChanged += new System.EventHandler(this.TopMostheckBox_CheckedChanged);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.Location = new System.Drawing.Point(389, 27);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(110, 42);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset Statistics";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // RawGroupBox
            // 
            this.RawGroupBox.Controls.Add(this.panel2);
            this.RawGroupBox.Controls.Add(this.panel1);
            this.RawGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.RawGroupBox.Location = new System.Drawing.Point(6, 169);
            this.RawGroupBox.Name = "RawGroupBox";
            this.RawGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.RawGroupBox.Size = new System.Drawing.Size(555, 208);
            this.RawGroupBox.TabIndex = 0;
            this.RawGroupBox.TabStop = false;
            this.RawGroupBox.Text = "Statistics";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 104);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TrafficChart);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(535, 104);
            this.panel3.TabIndex = 1;
            // 
            // TrafficChart
            // 
            this.TrafficChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.Interval = 3D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX2.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelStyle.Interval = 0D;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.TrafficChart.ChartAreas.Add(chartArea1);
            this.TrafficChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Font = new System.Drawing.Font("Consolas", 8F);
            legend1.IsTextAutoFit = false;
            legend1.MaximumAutoSize = 80F;
            legend1.Name = "Legend1";
            this.TrafficChart.Legends.Add(legend1);
            this.TrafficChart.Location = new System.Drawing.Point(0, 0);
            this.TrafficChart.Name = "TrafficChart";
            this.TrafficChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Consolas", 8F);
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Inbound";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Font = new System.Drawing.Font("Consolas", 8F);
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Outbound";
            this.TrafficChart.Series.Add(series1);
            this.TrafficChart.Series.Add(series2);
            this.TrafficChart.Size = new System.Drawing.Size(535, 104);
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
            this.panel1.Size = new System.Drawing.Size(535, 71);
            this.panel1.TabIndex = 4;
            // 
            // RawOutboundSpeed
            // 
            this.RawOutboundSpeed.AutoSize = true;
            this.RawOutboundSpeed.Location = new System.Drawing.Point(369, 40);
            this.RawOutboundSpeed.Name = "RawOutboundSpeed";
            this.RawOutboundSpeed.Size = new System.Drawing.Size(79, 13);
            this.RawOutboundSpeed.TabIndex = 7;
            this.RawOutboundSpeed.Text = "Raw Outbound";
            // 
            // RawInboundSpeed
            // 
            this.RawInboundSpeed.AutoSize = true;
            this.RawInboundSpeed.Location = new System.Drawing.Point(98, 40);
            this.RawInboundSpeed.Name = "RawInboundSpeed";
            this.RawInboundSpeed.Size = new System.Drawing.Size(105, 13);
            this.RawInboundSpeed.TabIndex = 6;
            this.RawInboundSpeed.Text = "Raw Inbound Speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inbound:";
            // 
            // RawOutbound
            // 
            this.RawOutbound.AutoSize = true;
            this.RawOutbound.Location = new System.Drawing.Point(369, 14);
            this.RawOutbound.Name = "RawOutbound";
            this.RawOutbound.Size = new System.Drawing.Size(79, 13);
            this.RawOutbound.TabIndex = 3;
            this.RawOutbound.Text = "Raw Outbound";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Outbound:";
            // 
            // RawInbound
            // 
            this.RawInbound.AutoSize = true;
            this.RawInbound.Location = new System.Drawing.Point(98, 14);
            this.RawInbound.Name = "RawInbound";
            this.RawInbound.Size = new System.Drawing.Size(71, 13);
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
            this.groupBox1.Controls.Add(this.ChartComboBox);
            this.groupBox1.Controls.Add(this.CleanLogsButton);
            this.groupBox1.Controls.Add(this.ResetButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TopMostheckBox);
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
            this.groupBox1.Size = new System.Drawing.Size(555, 163);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Panel";
            // 
            // CleanLogsButton
            // 
            this.CleanLogsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CleanLogsButton.Location = new System.Drawing.Point(389, 78);
            this.CleanLogsButton.Name = "CleanLogsButton";
            this.CleanLogsButton.Size = new System.Drawing.Size(110, 42);
            this.CleanLogsButton.TabIndex = 6;
            this.CleanLogsButton.Text = "Clean Logs";
            this.CleanLogsButton.UseVisualStyleBackColor = true;
            this.CleanLogsButton.Click += new System.EventHandler(this.CleanLogsButton_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(6, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 92);
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
            this.LogTextBox.Location = new System.Drawing.Point(3, 16);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(549, 73);
            this.LogTextBox.TabIndex = 0;
            this.LogTextBox.WordWrap = false;
            // 
            // ChartComboBox
            // 
            this.ChartComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChartComboBox.FormattingEnabled = true;
            this.ChartComboBox.Location = new System.Drawing.Point(71, 132);
            this.ChartComboBox.Name = "ChartComboBox";
            this.ChartComboBox.Size = new System.Drawing.Size(164, 21);
            this.ChartComboBox.TabIndex = 7;
            this.ChartComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Chart:";
            // 
            // TrafficStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 475);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.RawGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrafficStatisticsForm";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic Statistics";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
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
        private System.Windows.Forms.CheckBox TopMostheckBox;
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
    }
}