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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrafficStatisticsForm));
            this.myTabControl1 = new TrafficStatistics.MyTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.trafficStatisticsPanel1 = new TrafficStatistics.TrafficStatisticsPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myTabControl1
            // 
            this.myTabControl1.Controls.Add(this.tabPage1);
            this.myTabControl1.Controls.Add(this.tabPage2);
            this.myTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.myTabControl1.ItemSize = new System.Drawing.Size(50, 25);
            this.myTabControl1.Location = new System.Drawing.Point(6, 6);
            this.myTabControl1.Name = "myTabControl1";
            this.myTabControl1.SelectedIndex = 0;
            this.myTabControl1.Size = new System.Drawing.Size(534, 471);
            this.myTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.trafficStatisticsPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "[0]";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // trafficStatisticsPanel1
            // 
            this.trafficStatisticsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trafficStatisticsPanel1.Location = new System.Drawing.Point(3, 3);
            this.trafficStatisticsPanel1.Name = "trafficStatisticsPanel1";
            this.trafficStatisticsPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.trafficStatisticsPanel1.Size = new System.Drawing.Size(520, 432);
            this.trafficStatisticsPanel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "[+]";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TrafficStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 483);
            this.Controls.Add(this.myTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrafficStatisticsForm";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic Statistics";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.myTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyTabControl myTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private TrafficStatisticsPanel trafficStatisticsPanel1;
    }
}