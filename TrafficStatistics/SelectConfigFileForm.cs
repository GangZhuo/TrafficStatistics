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
    public partial class SelectConfigFileForm : Form
    {

        public string ConfigFile
        {
            get { return txConfigFile.Text; }
            set { txConfigFile.Text = value; }
        }

        public SelectConfigFileForm()
        {
            InitializeComponent();
        }

        private void SelectConfigFileForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(ConfigFile);
                openFileDialog1.FileName = ConfigFile;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ConfigFile = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ConfigFile))
                {
                    MessageBox.Show("Please select a config file");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
