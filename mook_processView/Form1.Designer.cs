namespace mook_processView
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lvView = new ListView();
            chPid = new ColumnHeader();
            chTime = new ColumnHeader();
            chMemory = new ColumnHeader();
            chName = new ColumnHeader();
            btnKill = new Button();
            ssBar = new StatusStrip();
            tsslProcess = new ToolStripStatusLabel();
            tsslCpu = new ToolStripStatusLabel();
            tsslMem = new ToolStripStatusLabel();
            ssBar.SuspendLayout();
            SuspendLayout();
            // 
            // lvView
            // 
            lvView.Columns.AddRange(new ColumnHeader[] { chPid, chTime, chMemory, chName });
            lvView.FullRowSelect = true;
            lvView.GridLines = true;
            lvView.Location = new Point(22, 23);
            lvView.Name = "lvView";
            lvView.Size = new Size(553, 274);
            lvView.TabIndex = 0;
            lvView.UseCompatibleStateImageBehavior = false;
            lvView.View = View.Details;
            // 
            // chPid
            // 
            chPid.DisplayIndex = 1;
            chPid.Text = "PID";
            chPid.TextAlign = HorizontalAlignment.Center;
            // 
            // chTime
            // 
            chTime.DisplayIndex = 2;
            chTime.Text = "Time";
            chTime.TextAlign = HorizontalAlignment.Center;
            chTime.Width = 90;
            // 
            // chMemory
            // 
            chMemory.DisplayIndex = 3;
            chMemory.Text = "메모리 사용";
            chMemory.TextAlign = HorizontalAlignment.Right;
            chMemory.Width = 100;
            // 
            // chName
            // 
            chName.DisplayIndex = 0;
            chName.Text = "프로세스 이름";
            chName.Width = 108;
            // 
            // btnKill
            // 
            btnKill.Location = new Point(22, 303);
            btnKill.Name = "btnKill";
            btnKill.Size = new Size(106, 23);
            btnKill.TabIndex = 1;
            btnKill.Text = "프로세스 끝내기";
            btnKill.UseVisualStyleBackColor = true;
            btnKill.Click += btnKill_Click;
            // 
            // ssBar
            // 
            ssBar.Items.AddRange(new ToolStripItem[] { tsslProcess, tsslCpu, tsslMem });
            ssBar.Location = new Point(0, 428);
            ssBar.Name = "ssBar";
            ssBar.Size = new Size(587, 22);
            ssBar.TabIndex = 2;
            ssBar.Text = "statusStrip1";
            // 
            // tsslProcess
            // 
            tsslProcess.Name = "tsslProcess";
            tsslProcess.Size = new Size(85, 17);
            tsslProcess.Text = "프로세스 : 0개";
            // 
            // tsslCpu
            // 
            tsslCpu.Name = "tsslCpu";
            tsslCpu.Size = new Size(86, 17);
            tsslCpu.Text = "CPU 사용 : 0%";
            // 
            // tsslMem
            // 
            tsslMem.Name = "tsslMem";
            tsslMem.Size = new Size(99, 17);
            tsslMem.Text = "실제 메모리 : 0%";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 450);
            Controls.Add(ssBar);
            Controls.Add(btnKill);
            Controls.Add(lvView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ssBar.ResumeLayout(false);
            ssBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvView;
        private Button btnKill;
        private ColumnHeader chName;
        private ColumnHeader chPid;
        private ColumnHeader chTime;
        private ColumnHeader chMemory;
        private StatusStrip ssBar;
        private ToolStripStatusLabel tsslProcess;
        private ToolStripStatusLabel tsslCpu;
        private ToolStripStatusLabel tsslMem;
    }
}
