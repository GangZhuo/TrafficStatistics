using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficStatistics
{
    public partial class AddForm : Form
    {
        public string Protocol
        {
            get { return TypeComboBox.SelectedItem as string; }
            set { TypeComboBox.SelectedItem = value; }
        }

        public string LocalAddress
        {
            get { return LeftAddressTextBox.Text.Trim(); }
            set { LeftAddressTextBox.Text = value; }
        }

        public string RemoteAddress
        {
            get { return RightTextBox.Text.Trim(); }
            set { RightTextBox.Text = value; }
        }

        public bool PrintPayload
        {
            get { return PrintPayloadCheckBox.Checked; }
            set { PrintPayloadCheckBox.Checked = value; }
        }

        public string Socks5Address
        {
            get { return txSocks5Address.Text.Trim(); }
            set { txSocks5Address.Text = value; }
        }

        public bool UseSocks5
        {
            get { return chkUseSocks5.Checked; }
            set { chkUseSocks5.Checked = value; }
        }

        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (TypeComboBox.SelectedIndex == -1)
                    TypeComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Protocol))
                {
                    MessageBox.Show("Please select Protocol");
                    return;
                }
                if (string.IsNullOrEmpty(LocalAddress))
                {
                    MessageBox.Show("Please input Local Address");
                    return;
                }
                if (string.IsNullOrEmpty(RemoteAddress))
                {
                    MessageBox.Show("Please input Remote Address");
                    return;
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
