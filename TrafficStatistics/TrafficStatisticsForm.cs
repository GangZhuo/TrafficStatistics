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
    public partial class TrafficStatisticsForm : Form
    {
        private int _id = 0;

        public TrafficStatisticsForm()
        {
            InitializeComponent();
            myTabControl1.SelectedIndexChanged += MyTabControl1_SelectedIndexChanged;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {

        }

        private void MyTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myTabControl1.SelectedIndex == myTabControl1.TabCount - 1)
            {
                var tabpage = new TabPage($"[{(++_id)}]");
                var panel = new TrafficStatisticsPanel();
                panel.Dock = DockStyle.Fill;
                tabpage.Controls.Add(panel);
                myTabControl1.TabPages.Insert(myTabControl1.TabCount - 1, tabpage);
                myTabControl1.SelectedIndex = myTabControl1.TabCount - 2;
            }
        }


    }
}
