namespace ljmonitor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.fdSave = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAI7 = new System.Windows.Forms.CheckBox();
            this.chkAI6 = new System.Windows.Forms.CheckBox();
            this.chkAI5 = new System.Windows.Forms.CheckBox();
            this.chkAI4 = new System.Windows.Forms.CheckBox();
            this.chkAI3 = new System.Windows.Forms.CheckBox();
            this.chkAI2 = new System.Windows.Forms.CheckBox();
            this.chkAI1 = new System.Windows.Forms.CheckBox();
            this.chkAI0 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkReverseDirection = new System.Windows.Forms.CheckBox();
            this.txtTimeToZero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interval:                     s";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(63, 12);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(51, 20);
            this.txtInterval.TabIndex = 1;
            this.txtInterval.Text = "0";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRun.Image = global::ljmonitor.Properties.Resources.media_playback_start;
            this.btnRun.Location = new System.Drawing.Point(61, 108);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // fdSave
            // 
            this.fdSave.Filter = "CSV Files|*.csv|TXT Files|*.txt|All Files|*.*";
            this.fdSave.OverwritePrompt = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.chkAI7);
            this.groupBox1.Controls.Add(this.chkAI6);
            this.groupBox1.Controls.Add(this.chkAI5);
            this.groupBox1.Controls.Add(this.chkAI4);
            this.groupBox1.Controls.Add(this.chkAI3);
            this.groupBox1.Controls.Add(this.chkAI2);
            this.groupBox1.Controls.Add(this.chkAI1);
            this.groupBox1.Controls.Add(this.chkAI0);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 64);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analog Inputs";
            // 
            // chkAI7
            // 
            this.chkAI7.AutoSize = true;
            this.chkAI7.Location = new System.Drawing.Point(123, 41);
            this.chkAI7.Name = "chkAI7";
            this.chkAI7.Size = new System.Drawing.Size(32, 17);
            this.chkAI7.TabIndex = 7;
            this.chkAI7.Text = "7";
            this.chkAI7.UseVisualStyleBackColor = true;
            // 
            // chkAI6
            // 
            this.chkAI6.AutoSize = true;
            this.chkAI6.Location = new System.Drawing.Point(85, 41);
            this.chkAI6.Name = "chkAI6";
            this.chkAI6.Size = new System.Drawing.Size(32, 17);
            this.chkAI6.TabIndex = 6;
            this.chkAI6.Text = "6";
            this.chkAI6.UseVisualStyleBackColor = true;
            // 
            // chkAI5
            // 
            this.chkAI5.AutoSize = true;
            this.chkAI5.Location = new System.Drawing.Point(47, 41);
            this.chkAI5.Name = "chkAI5";
            this.chkAI5.Size = new System.Drawing.Size(32, 17);
            this.chkAI5.TabIndex = 5;
            this.chkAI5.Text = "5";
            this.chkAI5.UseVisualStyleBackColor = true;
            // 
            // chkAI4
            // 
            this.chkAI4.AutoSize = true;
            this.chkAI4.Location = new System.Drawing.Point(9, 41);
            this.chkAI4.Name = "chkAI4";
            this.chkAI4.Size = new System.Drawing.Size(32, 17);
            this.chkAI4.TabIndex = 4;
            this.chkAI4.Text = "4";
            this.chkAI4.UseVisualStyleBackColor = true;
            // 
            // chkAI3
            // 
            this.chkAI3.AutoSize = true;
            this.chkAI3.Location = new System.Drawing.Point(123, 19);
            this.chkAI3.Name = "chkAI3";
            this.chkAI3.Size = new System.Drawing.Size(32, 17);
            this.chkAI3.TabIndex = 3;
            this.chkAI3.Text = "3";
            this.chkAI3.UseVisualStyleBackColor = true;
            // 
            // chkAI2
            // 
            this.chkAI2.AutoSize = true;
            this.chkAI2.Location = new System.Drawing.Point(85, 19);
            this.chkAI2.Name = "chkAI2";
            this.chkAI2.Size = new System.Drawing.Size(32, 17);
            this.chkAI2.TabIndex = 2;
            this.chkAI2.Text = "2";
            this.chkAI2.UseVisualStyleBackColor = true;
            // 
            // chkAI1
            // 
            this.chkAI1.AutoSize = true;
            this.chkAI1.Checked = true;
            this.chkAI1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAI1.Location = new System.Drawing.Point(47, 19);
            this.chkAI1.Name = "chkAI1";
            this.chkAI1.Size = new System.Drawing.Size(32, 17);
            this.chkAI1.TabIndex = 1;
            this.chkAI1.Text = "1";
            this.chkAI1.UseVisualStyleBackColor = true;
            // 
            // chkAI0
            // 
            this.chkAI0.AutoSize = true;
            this.chkAI0.Checked = true;
            this.chkAI0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAI0.Location = new System.Drawing.Point(9, 19);
            this.chkAI0.Name = "chkAI0";
            this.chkAI0.Size = new System.Drawing.Size(32, 17);
            this.chkAI0.TabIndex = 0;
            this.chkAI0.Text = "0";
            this.chkAI0.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkReverseDirection);
            this.groupBox2.Controls.Add(this.txtTimeToZero);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Direction";
            this.groupBox2.Visible = false;
            // 
            // chkReverseDirection
            // 
            this.chkReverseDirection.AutoSize = true;
            this.chkReverseDirection.Location = new System.Drawing.Point(9, 48);
            this.chkReverseDirection.Name = "chkReverseDirection";
            this.chkReverseDirection.Size = new System.Drawing.Size(111, 17);
            this.chkReverseDirection.TabIndex = 2;
            this.chkReverseDirection.Text = "Reverse Direction";
            this.chkReverseDirection.UseVisualStyleBackColor = true;
            // 
            // txtTimeToZero
            // 
            this.txtTimeToZero.Location = new System.Drawing.Point(75, 22);
            this.txtTimeToZero.Name = "txtTimeToZero";
            this.txtTimeToZero.Size = new System.Drawing.Size(55, 20);
            this.txtTimeToZero.TabIndex = 1;
            this.txtTimeToZero.Text = "0.2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time to zero:                       s";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 138);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LJ Monitor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.SaveFileDialog fdSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAI3;
        private System.Windows.Forms.CheckBox chkAI2;
        private System.Windows.Forms.CheckBox chkAI1;
        private System.Windows.Forms.CheckBox chkAI0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkReverseDirection;
        private System.Windows.Forms.TextBox txtTimeToZero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAI7;
        private System.Windows.Forms.CheckBox chkAI6;
        private System.Windows.Forms.CheckBox chkAI5;
        private System.Windows.Forms.CheckBox chkAI4;
    }
}

