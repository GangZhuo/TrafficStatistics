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
using System.Xml.Linq;

namespace TrafficStatistics
{
    public partial class TrafficStatisticsForm : Form
    {
        private ListViewItem _SelectedItem;

        public TrafficStatisticsForm()
        {
            InitializeComponent();
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            btnEdit.Enabled = btnDelete.Enabled = false;
            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            listView1.DoubleClick += ListView1_DoubleClick;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _SelectedItem = (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
                    ? listView1.SelectedItems[0] : null;
                btnEdit.Enabled = btnDelete.Enabled = _SelectedItem != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_SelectedItem == null || _SelectedItem.Tag == null || !(_SelectedItem.Tag is ItemInfo))
                    return;
                var info = _SelectedItem.Tag as ItemInfo;

                var tabPage = new TabPage($"{info.Protocol}:{info.LocalAddress}");
                var body = new TrafficStatisticsPanel();
                body.ItemInfo = info;
                body.Dock = DockStyle.Fill;
                tabPage.Controls.Add(body);
                tabControl1.TabPages.Add(tabPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new AddForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var info = new ItemInfo
                    {
                        Protocol = frm.Protocol,
                        LocalAddress = frm.LocalAddress,
                        RemoteAddress = frm.RemoteAddress,
                        PrintPayload = frm.PrintPayload
                    };
                    var lvitem = new ListViewItem(new string[] {
                        info.Protocol,
                        info.LocalAddress,
                        info.RemoteAddress
                    });
                    lvitem.Tag = info;
                    this.listView1.Items.Add(lvitem);
                    SaveItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SelectedItem == null || _SelectedItem.Tag == null || !(_SelectedItem.Tag is ItemInfo))
                    return;
                var info = _SelectedItem.Tag as ItemInfo;
                var frm = new AddForm();
                frm.Protocol = info.Protocol;
                frm.LocalAddress = info.LocalAddress;
                frm.RemoteAddress = info.RemoteAddress;
                frm.PrintPayload = info.PrintPayload;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    info.Protocol = frm.Protocol;
                    info.LocalAddress = frm.LocalAddress;
                    info.RemoteAddress = frm.RemoteAddress;
                    info.PrintPayload = frm.PrintPayload;

                    _SelectedItem.Text = info.Protocol;
                    _SelectedItem.SubItems[0].Text = info.Protocol;
                    _SelectedItem.SubItems[1].Text = info.LocalAddress;
                    _SelectedItem.SubItems[2].Text = info.RemoteAddress;

                    SaveItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SelectedItem == null || _SelectedItem.Tag == null || !(_SelectedItem.Tag is ItemInfo))
                    return;
                if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var item = _SelectedItem;
                    _SelectedItem = null;
                    listView1.Items.Remove(item);
                    SaveItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveItems()
        {
            var filename = "item.xml";
            var xdoc = new XDocument();
            var xroot = new XElement("items");
            xdoc.Add(xroot);

            foreach(ListViewItem item in listView1.Items)
            {
                var info = item.Tag as ItemInfo;
                var xelem = new XElement("item");

                xelem.Add(new XAttribute("proto", info.Protocol));
                xelem.Add(new XAttribute("local", info.LocalAddress));
                xelem.Add(new XAttribute("remote", info.RemoteAddress));
                xelem.Add(new XAttribute("print", info.PrintPayload ? "true" : "false"));

                xroot.Add(xelem);
            }

            using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                xdoc.Save(fs);
            }
        }

        private void LoadItems()
        {
            var filename = "item.xml";
            if (File.Exists(filename))
            {
                var xdoc = XDocument.Load(filename);
                var list = xdoc.Root.Elements().Where(x => x.Name == "item")
                    .Select(x => new ItemInfo
                    {
                        Protocol = x.Attribute("proto").Value,
                        LocalAddress = x.Attribute("local").Value,
                        RemoteAddress = x.Attribute("remote").Value,
                        PrintPayload = x.Attribute("print").Value == "true"
                    });
                listView1.Items.Clear();
                foreach(ItemInfo info in list)
                {
                    var lvitem = new ListViewItem(new string[] {
                        info.Protocol,
                        info.LocalAddress,
                        info.RemoteAddress
                    });
                    lvitem.Tag = info;
                    this.listView1.Items.Add(lvitem);
                }
            }
        }
    }
}
