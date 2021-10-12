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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.localStat = new TrafficStatistics.StatPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.remoteStat = new TrafficStatistics.StatPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PrintPayloadAsTextCheckBox = new System.Windows.Forms.CheckBox();
            this.PrintRemotePayloadCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.txSocks5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PrintLocalPayloadCheckBox = new System.Windows.Forms.CheckBox();
            this.ChartComboBox = new System.Windows.Forms.ComboBox();
            this.CleanLogsButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RawGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.StopButton.Location = new System.Drawing.Point(499, 41);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(110, 28);
            this.StopButton.TabIndex = 5;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(499, 12);
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
            this.RightTextBox.Size = new System.Drawing.Size(164, 22);
            this.RightTextBox.TabIndex = 2;
            this.RightTextBox.Text = "127.0.0.1:5211";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Remote:";
            // 
            // LeftAddressTextBox
            // 
            this.LeftAddressTextBox.Location = new System.Drawing.Point(71, 47);
            this.LeftAddressTextBox.MaxLength = 200;
            this.LeftAddressTextBox.Name = "LeftAddressTextBox";
            this.LeftAddressTextBox.Size = new System.Drawing.Size(164, 22);
            this.LeftAddressTextBox.TabIndex = 1;
            this.LeftAddressTextBox.Text = "127.0.0.1:5210";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 12);
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
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type:";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(615, 12);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(110, 28);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset Statistics";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // RawGroupBox
            // 
            this.RawGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.RawGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawGroupBox.Location = new System.Drawing.Point(0, 0);
            this.RawGroupBox.Name = "RawGroupBox";
            this.RawGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.RawGroupBox.Size = new System.Drawing.Size(785, 165);
            this.RawGroupBox.TabIndex = 0;
            this.RawGroupBox.TabStop = false;
            this.RawGroupBox.Text = "Statistics";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.localStat);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 144);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Local";
            // 
            // localStat
            // 
            this.localStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localStat.Location = new System.Drawing.Point(3, 18);
            this.localStat.Name = "localStat";
            this.localStat.Size = new System.Drawing.Size(380, 123);
            this.localStat.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.remoteStat);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(395, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 144);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remote";
            // 
            // remoteStat
            // 
            this.remoteStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteStat.Location = new System.Drawing.Point(3, 18);
            this.remoteStat.Name = "remoteStat";
            this.remoteStat.Size = new System.Drawing.Size(381, 123);
            this.remoteStat.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PrintPayloadAsTextCheckBox);
            this.groupBox1.Controls.Add(this.PrintRemotePayloadCheckBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkUseProxy);
            this.groupBox1.Controls.Add(this.txSocks5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.PrintLocalPayloadCheckBox);
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
            this.groupBox1.Size = new System.Drawing.Size(785, 130);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Panel";
            // 
            // PrintPayloadAsTextCheckBox
            // 
            this.PrintPayloadAsTextCheckBox.AutoSize = true;
            this.PrintPayloadAsTextCheckBox.Location = new System.Drawing.Point(465, 101);
            this.PrintPayloadAsTextCheckBox.Name = "PrintPayloadAsTextCheckBox";
            this.PrintPayloadAsTextCheckBox.Size = new System.Drawing.Size(122, 16);
            this.PrintPayloadAsTextCheckBox.TabIndex = 14;
            this.PrintPayloadAsTextCheckBox.Text = "Print Payload as Text";
            this.PrintPayloadAsTextCheckBox.UseVisualStyleBackColor = true;
            this.PrintPayloadAsTextCheckBox.CheckedChanged += new System.EventHandler(this.PrintPayloadAsTextCheckBox_CheckedChanged);
            // 
            // PrintRemotePayloadCheckBox
            // 
            this.PrintRemotePayloadCheckBox.AutoSize = true;
            this.PrintRemotePayloadCheckBox.Location = new System.Drawing.Point(313, 101);
            this.PrintRemotePayloadCheckBox.Name = "PrintRemotePayloadCheckBox";
            this.PrintRemotePayloadCheckBox.Size = new System.Drawing.Size(125, 16);
            this.PrintRemotePayloadCheckBox.TabIndex = 13;
            this.PrintRemotePayloadCheckBox.Text = "Print Remote Payload";
            this.PrintRemotePayloadCheckBox.UseVisualStyleBackColor = true;
            this.PrintRemotePayloadCheckBox.CheckedChanged += new System.EventHandler(this.PrintRemotePayloadCheckBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(397, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "(Only for TCP)";
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.Location = new System.Drawing.Point(313, 49);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(72, 16);
            this.chkUseProxy.TabIndex = 11;
            this.chkUseProxy.Text = "Use Proxy";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            // 
            // txSocks5
            // 
            this.txSocks5.Location = new System.Drawing.Point(313, 19);
            this.txSocks5.Name = "txSocks5";
            this.txSocks5.Size = new System.Drawing.Size(173, 22);
            this.txSocks5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Socks5:";
            // 
            // PrintLocalPayloadCheckBox
            // 
            this.PrintLocalPayloadCheckBox.AutoSize = true;
            this.PrintLocalPayloadCheckBox.Location = new System.Drawing.Point(313, 79);
            this.PrintLocalPayloadCheckBox.Name = "PrintLocalPayloadCheckBox";
            this.PrintLocalPayloadCheckBox.Size = new System.Drawing.Size(115, 16);
            this.PrintLocalPayloadCheckBox.TabIndex = 8;
            this.PrintLocalPayloadCheckBox.Text = "Print Local Payload";
            this.PrintLocalPayloadCheckBox.UseVisualStyleBackColor = true;
            this.PrintLocalPayloadCheckBox.CheckedChanged += new System.EventHandler(this.PrintLocalPayloadCheckBox_CheckedChanged);
            // 
            // ChartComboBox
            // 
            this.ChartComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChartComboBox.FormattingEnabled = true;
            this.ChartComboBox.Location = new System.Drawing.Point(71, 101);
            this.ChartComboBox.Name = "ChartComboBox";
            this.ChartComboBox.Size = new System.Drawing.Size(164, 20);
            this.ChartComboBox.TabIndex = 7;
            this.ChartComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartComboBox_SelectedIndexChanged);
            // 
            // CleanLogsButton
            // 
            this.CleanLogsButton.Location = new System.Drawing.Point(615, 41);
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
            this.label5.Location = new System.Drawing.Point(16, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Chart:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LogTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(785, 166);
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
            this.LogTextBox.Location = new System.Drawing.Point(3, 18);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(779, 145);
            this.LogTextBox.TabIndex = 0;
            this.LogTextBox.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(6, 136);
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
            this.splitContainer1.Size = new System.Drawing.Size(785, 335);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 7;
            // 
            // TrafficStatisticsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "TrafficStatisticsPanel";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(797, 477);
            this.Load += new System.EventHandler(this.TrafficStatisticsPanel_Load);
            this.RawGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button CleanLogsButton;
        private System.Windows.Forms.ComboBox ChartComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox PrintLocalPayloadCheckBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txSocks5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private StatPanel localStat;
        private StatPanel remoteStat;
        private System.Windows.Forms.CheckBox PrintRemotePayloadCheckBox;
        private System.Windows.Forms.CheckBox PrintPayloadAsTextCheckBox;
    }
}
