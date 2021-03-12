
namespace TrafficStatistics
{
    partial class StatPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSendSpeed = new System.Windows.Forms.Label();
            this.lbSendTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecvSpeed = new System.Windows.Forms.Label();
            this.lbRecvTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TrafficChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbSendSpeed);
            this.panel1.Controls.Add(this.lbSendTotal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbRecvSpeed);
            this.panel1.Controls.Add(this.lbRecvTotal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 55);
            this.panel1.TabIndex = 0;
            // 
            // lbSendSpeed
            // 
            this.lbSendSpeed.AutoSize = true;
            this.lbSendSpeed.Location = new System.Drawing.Point(222, 32);
            this.lbSendSpeed.Name = "lbSendSpeed";
            this.lbSendSpeed.Size = new System.Drawing.Size(33, 12);
            this.lbSendSpeed.TabIndex = 14;
            this.lbSendSpeed.Text = "label2";
            // 
            // lbSendTotal
            // 
            this.lbSendTotal.AutoSize = true;
            this.lbSendTotal.Location = new System.Drawing.Point(222, 10);
            this.lbSendTotal.Name = "lbSendTotal";
            this.lbSendTotal.Size = new System.Drawing.Size(33, 12);
            this.lbSendTotal.TabIndex = 13;
            this.lbSendTotal.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Send:";
            // 
            // lbRecvSpeed
            // 
            this.lbRecvSpeed.AutoSize = true;
            this.lbRecvSpeed.Location = new System.Drawing.Point(61, 32);
            this.lbRecvSpeed.Name = "lbRecvSpeed";
            this.lbRecvSpeed.Size = new System.Drawing.Size(33, 12);
            this.lbRecvSpeed.TabIndex = 11;
            this.lbRecvSpeed.Text = "label2";
            // 
            // lbRecvTotal
            // 
            this.lbRecvTotal.AutoSize = true;
            this.lbRecvTotal.Location = new System.Drawing.Point(61, 10);
            this.lbRecvTotal.Name = "lbRecvTotal";
            this.lbRecvTotal.Size = new System.Drawing.Size(33, 12);
            this.lbRecvTotal.TabIndex = 10;
            this.lbRecvTotal.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Recv:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TrafficChart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 297);
            this.panel2.TabIndex = 1;
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
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
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
            this.TrafficChart.Size = new System.Drawing.Size(536, 297);
            this.TrafficChart.TabIndex = 1;
            this.TrafficChart.Text = "Traffic Chart";
            // 
            // StatPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StatPanel";
            this.Size = new System.Drawing.Size(536, 352);
            this.Load += new System.EventHandler(this.StatPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrafficChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbRecvTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRecvSpeed;
        private System.Windows.Forms.Label lbSendSpeed;
        private System.Windows.Forms.Label lbSendTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart TrafficChart;
    }
}
