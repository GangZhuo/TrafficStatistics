using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficStatistics
{
    static class Program
    {
        static NotifyIcon _notifyIcon;
        static ContextMenu contextMenu1;
        static TrafficStatisticsForm form;
        static bool closing;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CreateContextMenu();
            CreateTrayIcon();
            form = new TrafficStatisticsForm();
            form.FormClosing += MainForm_FormClosing;
            form.Show();
            form.Activate();
            Application.Run();
        }

        static void CreateContextMenu()
        {
            contextMenu1 = new ContextMenu(new MenuItem[] {
                new MenuItem("Open", new EventHandler(OnOpenMainFormMenuItemClick)),
                new MenuItem("-"),
                new MenuItem("Quit", new EventHandler(OnQuitMenuItemClick))
            });
        }

        static void CreateTrayIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.DoubleClick += OnNotifyIconDoubleClick;
            _notifyIcon.BalloonTipClicked += OnBalloonTipClicked;
            _notifyIcon.Icon = Properties.Resources.wave;
            _notifyIcon.Text = "Traffic Statistics";
            _notifyIcon.Visible = true;
            _notifyIcon.ContextMenu = contextMenu1;
        }

        static void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            form.Show();
            form.Activate();
        }

        static void OnBalloonTipClicked(object sender, EventArgs e)
        {
            
        }

        static void OnOpenMainFormMenuItemClick(object sender, EventArgs e)
        {
            form.Show();
            form.Activate();
        }

        static void OnQuitMenuItemClick(object sender, EventArgs e)
        {
            closing = true;
            form.Close();
            Application.Exit();
        }

        private static void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                e.Cancel = true;
                form.Hide();
            }
        }

    }
}
