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

                var info = _SelectedItem?.Tag as ItemInfo;

                if (info != null)
                {
                    // highlight tab
                    foreach (TabPage tabPage in this.tabControl1.TabPages)
                    {
                        TrafficStatisticsPanel body = (TrafficStatisticsPanel)tabPage.Controls[0];
                        if (body.ItemInfo == info)
                        {
                            this.tabControl1.SelectedTab = tabPage;
                            break;
                        }
                    }
                }
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
                        PrintPayload = frm.PrintPayload,
                        Socks5Address = frm.Socks5Address,
                        UseSocks5Proxy = frm.UseSocks5,
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
                frm.Socks5Address = info.Socks5Address;
                frm.UseSocks5 = info.UseSocks5Proxy;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    info.Protocol = frm.Protocol;
                    info.LocalAddress = frm.LocalAddress;
                    info.RemoteAddress = frm.RemoteAddress;
                    info.PrintPayload = frm.PrintPayload;
                    info.Socks5Address = frm.Socks5Address;
                    info.UseSocks5Proxy = frm.UseSocks5;

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
                xelem.Add(new XAttribute("socks5", info.Socks5Address));
                xelem.Add(new XAttribute("proxy", info.UseSocks5Proxy ? "true" : "false"));
                xelem.Add(new XAttribute("chart", info.ChartRange));

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
                var toInt = new Func<string, int>((x) => {
                    int iv;
                    if (!string.IsNullOrEmpty(x) && int.TryParse(x, out iv))
                        return iv;
                    return 0;
                });
                var xdoc = XDocument.Load(filename);
                var list = xdoc.Root.Elements().Where(x => x.Name == "item")
                    .Select(x => new ItemInfo
                    {
                        Protocol = x.Attribute("proto").Value,
                        LocalAddress = x.Attribute("local").Value,
                        RemoteAddress = x.Attribute("remote").Value,
                        PrintPayload = x.Attribute("print").Value == "true",
                        Socks5Address = x.Attribute("socks5")?.Value ?? "127.0.0.1:1080",
                        UseSocks5Proxy = x.Attribute("proxy")?.Value == "true",
                        ChartRange = toInt(x.Attribute("chart")?.Value),
                    });
                listView1.Items.Clear();
                foreach(ItemInfo info in list)
                {
                    var lvitem = new ListViewItem(new string[] {
                        info.Protocol,
                        info.LocalAddress,
                        info.RemoteAddress,
                        info.Socks5Address,
                        info.UseSocks5Proxy ? "Y":"N",
                    });
                    lvitem.Tag = info;
                    this.listView1.Items.Add(lvitem);
                }
            }
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            try
            {
                var errors = new StringBuilder();
                foreach (ListViewItem lvitem in this.listView1.Items)
                {
                    ItemInfo info = (ItemInfo)lvitem.Tag;
                    try
                    {
                        var tabPage = new TabPage($"{info.Protocol}:{info.LocalAddress}");
                        var body = new TrafficStatisticsPanel();
                        body.ItemInfo = info;
                        body.AutoStart = true;
                        body.Dock = DockStyle.Fill;
                        tabPage.Controls.Add(body);
                        tabControl1.TabPages.Add(tabPage);
                    }
                    catch (Exception ex)
                    {
                        errors.AppendLine($"{info.Protocol}:{info.LocalAddress} 出错: {ex.Message}");
                    }
                }

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            try
            {
                var errors = new StringBuilder();
                foreach (TabPage tabPage in this.tabControl1.TabPages)
                {
                    TrafficStatisticsPanel body = (TrafficStatisticsPanel)tabPage.Controls[0];
                    try
                    {
                        body.Stop();
                    }
                    catch (Exception ex)
                    {
                        errors.AppendLine($"{tabPage.Text} 出错: {ex.Message}");
                    }
                }

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                }
                else
                {
                    this.tabControl1.TabPages.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
