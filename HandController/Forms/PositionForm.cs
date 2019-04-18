using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCOM.Ardufocus.Forms
{
    public partial class PositionForm : Form
    {
        public PositionForm()
        {
            InitializeComponent();
        }

        public int GetUserInput()
        {
            return (int) this.numericUpDown1.Value;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PositionForm_Shown(object sender, EventArgs e)
        {
            if (Context.CheckIfConnected())
            {
                this.numericUpDown1.Value = Context.Driver.Position;
            }

            this.numericUpDown1.Select();
            this.numericUpDown1.Select(0, numericUpDown1.Text.Length);
        }
    }
}
