using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

public partial class frmMockUp : Form
{
    public frmMockUp()
    {
        InitializeComponent();
    }

    public bool GetDState(int channel)
    {
        foreach (Control cnt in Controls)
            if (cnt.Tag != null && (int)cnt.Tag == channel)
                return cnt.BackColor == Color.Green;

        throw new Exception("Wrong channel");
    }

    public void SetDState(int channel, bool state)
    {
        foreach (Control cnt in Controls)
            if (cnt.Tag != null && (int)cnt.Tag == channel)
            {
                cnt.BackColor = state ? Color.Green : Color.Red;
                return;
            }

        throw new Exception("Wrong channel");
    }

    public float GetAState(int channel)
    {
        return Up.BackColor == Color.Green ? 2.0f :
            Still.BackColor == Color.Green ? 0.0f :
            -2.0f;
    }

    Label Up, Down, Still;

    private void frmMockUp_Load(object sender, EventArgs e)
    {
        int x = 5, y = 5, h = 32, w = 32, s = 5;
        Label lbl;

        for (int i = 0; i < 16; ++i)
        {
            lbl = new Label();
            lbl.Text = "D" + (i + 1);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.BackColor = Color.Red;
            lbl.Size = new Size(w, h);
            lbl.Top = y;
            lbl.Left = x;
            lbl.Tag = i;
            lbl.MouseDown += new MouseEventHandler(lbl_Click);

            x += w + s;

            if (i == 7)
            {
                x = s;
                y += s + h;
            }

            Controls.Add(lbl);
        }

        x = 5;
        y += h + s;

        Up = new Label();
        Up.Text = "^";
        Up.TextAlign = ContentAlignment.MiddleCenter;
        Up.BackColor = Color.Red;
        Up.Size = new Size(w, h);
        Up.Top = y;
        Up.Left = x;
        Up.MouseDown += new MouseEventHandler(lbl_Click);
        Controls.Add(Up);
        x += w + s;

        Still = new Label();
        Still.Text = "0";
        Still.TextAlign = ContentAlignment.MiddleCenter;
        Still.BackColor = Color.Green;
        Still.Size = new Size(w, h);
        Still.Top = y;
        Still.Left = x;
        Still.MouseDown += new MouseEventHandler(lbl_Click);
        Controls.Add(Still);
        x += w + s;

        Down = new Label();
        Down.Text = "v";
        Down.TextAlign = ContentAlignment.MiddleCenter;
        Down.BackColor = Color.Red;
        Down.Size = new Size(w, h);
        Down.Top = y;
        Down.Left = x;
        Down.MouseDown += new MouseEventHandler(lbl_Click);
        Controls.Add(Down);
        x += w + s;

        Width = 17 * s + 8 * w;
        Height = 4 * s + 3 * h + 30;
    }

    void lbl_Click(object sender, EventArgs e)
    {
        Control cnt = sender as Control;

        if (cnt == Up || cnt == Down || cnt == Still)
            Up.BackColor = Down.BackColor = Still.BackColor = Color.Red;

        cnt.BackColor = cnt.BackColor == Color.Red ? Color.Green : Color.Red;
    }
}