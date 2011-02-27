using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ljmonitor
{
    public partial class frmRunning : Form
    {
        int ms;
        string filename;
        volatile bool stop = false;
        bool ai0, ai1, ai2, ai3;
        int timetozeroms;
        bool reversedir;

        public frmRunning(int ms, string filename, bool ai0, bool ai1, bool ai2, bool ai3, int timetozeroms, bool reversedir)
        {
            this.ms = ms;
            this.filename = filename;
            this.ai0 = ai0; this.ai1 = ai1; this.ai2 = ai2; this.ai3 = ai3;
            this.timetozeroms = timetozeroms;
            this.reversedir = reversedir;

            InitializeComponent();
        }

        void ThreadStart()
        {
            DateTime last = DateTime.Now, lastdirectionpulse = DateTime.Now;
            const int dirpin1=0, dirpin2=1;
            string lastdir="";

            while (!stop)
            {
                DateTime now = DateTime.Now;
                if ((now - last).TotalMilliseconds < ms)
                    continue;
                last = now;

                // read all this crap and write it out
                int digitals = LJ.ReadIO();
                string emptycomma = !ai0 && !ai1 && !ai2 && !ai3 ? "," : "";
                long cnt = LJ.ReadCounter(true);

                // dir pulse?
                int p0 = digitals & 1, p1 = (digitals & 2) >> 1;
                if (p0 == 0)
                {
                    if (reversedir) p1 = 1 - p1;

                    lastdirectionpulse = now;
                    lastdir = p1 == 0 ? "^" : "v";
                }
                if ((now - lastdirectionpulse).TotalMilliseconds > timetozeroms)
                    lastdir = "0";


                File.AppendAllText(filename, string.Format(
                    "{0},{1},{2},{3},{4}{5},{6},\"{7}\"\n",
                    Math.Sign(digitals & 1),
                    Math.Sign(digitals & 2),
                    Math.Sign(digitals & 4),
                    Math.Sign(digitals & 8),
                    (ai0 ? LJ.ReadAnalogInput(0).ToString() + "," : "") + (ai1 ? LJ.ReadAnalogInput(1).ToString() + "," : "") + (ai2 ? LJ.ReadAnalogInput(2).ToString() + "," : "") + (ai3 ? LJ.ReadAnalogInput(3).ToString() + "," : "") + emptycomma,
                    cnt,
                    lastdir,
                    now.ToString("hh:mm:ss.fff")));
            }

            // at the end close the window
            Invoke((MethodInvoker)(() => { Close(); }));
        }

        private void frmRunning_Load(object sender, EventArgs e)
        {
            LJ.Init();

            var thread = new Thread(ThreadStart);
            thread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop = true;
            btnStop.Enabled = false;
        }

        private void frmRunning_FormClosing(object sender, FormClosingEventArgs e)
        {
            LJ.Destroy();
        }
    }
}
