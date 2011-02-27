using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ljmonitor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            double seconds, timetozeroseconds;
            if (double.TryParse(txtInterval.Text, out seconds) && double.TryParse(txtTimeToZero.Text, out timetozeroseconds))
            {
                if (fdSave.ShowDialog() == DialogResult.OK)
                    using (var running = new frmRunning((int)(seconds * 1000.0), fdSave.FileName, 
                        chkAI0.Checked, chkAI1.Checked, chkAI2.Checked, chkAI3.Checked,
                        (int)(seconds * 1000.0), chkReverseDirection.Checked))
                        running.ShowDialog();
            }
            else
                MessageBox.Show("The interval isn't numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }
    }
}
