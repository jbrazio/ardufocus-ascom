using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ASCOM.Ardufocus.Forms
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            this.Text = String.Format("{0}", Common.Metadata.DriverDescription);
            label2.Text = String.Format("Objects: {0}, Locks: {1}, Connections: {2}", Server.ObjectsCount, Server.ServerLockCount, SharedResources.Connections);

            try
            {
                List<string> Buffer = Context.LogBuffer;
                textBox1.Text = string.Join(Environment.NewLine, Buffer);
                textBox1.Select(0, 0);
            }
            catch (Exception) { }
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (! Server.StartedByCOM)
            {
                Application.Exit();
            }
        }
    }
}