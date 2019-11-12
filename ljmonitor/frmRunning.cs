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
        bool ai0, ai1, ai2, ai3, ai4, ai5, ai6, ai7;
        int timetozeroms;
        bool reversedir;
        DateTime started;

        public frmRunning(int ms, string filename, bool ai0, bool ai1, bool ai2, bool ai3,
            bool ai4, bool ai5, bool ai6, bool ai7, int timetozeroms, bool reversedir)
        {
            this.ms = ms;
            this.filename = filename;
            this.ai0 = ai0; this.ai1 = ai1; this.ai2 = ai2; this.ai3 = ai3;
            this.ai4 = ai4; this.ai5 = ai5; this.ai6 = ai6; this.ai7 = ai7;
            this.timetozeroms = timetozeroms;
            this.reversedir = reversedir;
            started = DateTime.Now;

            InitializeComponent();
        }

        void ThreadStart()
        {
            DateTime last = DateTime.Now, lastdirectionpulse = DateTime.Now;
            const int dirpin1 = 0, dirpin2 = 1;
            string lastdir = "";

            while (!stop)
            {
                DateTime now = DateTime.Now;
                if ((now - last).TotalMilliseconds < ms)
                    continue;
                last = now;

                // read all this crap and write it out
                //int digitals = LJ.ReadIO();
                string emptycomma = !ai0 && !ai1 && !ai2 && !ai3 && !ai4 && !ai5 && !ai6 && !ai7 ? "," : "";
                long cnt = LJ.ReadCounter(true);

                // dir pulse?
                //bool oktoprocessdir = true;
                //int p0 = digitals & 1, p1 = (digitals & 2) >> 1;
                //if (p0 == 0)
                //{
                //    if (oktoprocessdir)
                //    {
                //        if (reversedir) p1 = 1 - p1;

                //        lastdirectionpulse = now;
                //        lastdir = p1 == 0 ? "^" : "v";

                //        oktoprocessdir = false;
                //    }
                //}
                //else
                //    oktoprocessdir = true;

                //if ((now - lastdirectionpulse).TotalMilliseconds > timetozeroms)
                //    lastdir = "0";

                var vai0 = ai0 ? LJ.ReadAnalogInput(0) : (float?)null;
                var vai1 = ai1 ? LJ.ReadAnalogInput(1) : (float?)null;
                var vai2 = ai2 ? LJ.ReadAnalogInput(2) : (float?)null;
                var vai3 = ai3 ? LJ.ReadAnalogInput(3) : (float?)null;
                var vai4 = ai4 ? LJ.ReadAnalogInput(4) : (float?)null;
                var vai5 = ai5 ? LJ.ReadAnalogInput(5) : (float?)null;
                var vai6 = ai6 ? LJ.ReadAnalogInput(6) : (float?)null;
                var vai7 = ai7 ? LJ.ReadAnalogInput(7) : (float?)null;

                try
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        lblState.Text = string.Format("AI0: {0}\r\nAI1: {1}\r\nAI2: {2}\r\nAI3: {3}\r\nAI4: {4}\r\nAI5: {5}\r\nAI6: {6}\r\nAI7: {7}",
                            vai0.HasValue ? vai0.Value.ToString("0.00") : "---",
                            vai1.HasValue ? vai1.Value.ToString("0.00") : "---",
                            vai2.HasValue ? vai2.Value.ToString("0.00") : "---",
                            vai3.HasValue ? vai3.Value.ToString("0.00") : "---",
                            vai4.HasValue ? vai4.Value.ToString("0.00") : "---",
                            vai5.HasValue ? vai5.Value.ToString("0.00") : "---",
                            vai6.HasValue ? vai6.Value.ToString("0.00") : "---",
                            vai7.HasValue ? vai7.Value.ToString("0.00") : "---");
                    }));
                }
                catch
                {
                }

                File.AppendAllText(filename, string.Format(
                    "{0}{1},{2},\"{3}\",{4:0.0000}\n",
                    (ai0 ? vai0.ToString() + "," : "") + (ai1 ? vai1.ToString() + "," : "") + (ai2 ? vai2.ToString() + "," : "") + (ai3 ? vai3.ToString() + "," : "") + (ai4 ? vai4.ToString() + "," : "") + (ai5 ? vai5.ToString() + "," : "") + (ai6 ? vai6.ToString() + "," : "") + (ai7 ? vai7.ToString() + "," : "") + emptycomma,
                    cnt,
                    lastdir,
                    now.ToString("hh:mm:ss.fff"),
                    (DateTime.Now - started).TotalSeconds));
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
            btnStop.PerformClick();
            LJ.Destroy();
        }
    }
}
