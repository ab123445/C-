namespace WinForm0105
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            timer1 = new System.Windows.Forms.Timer(components);
            RightAnswer = new Label();
            WrongAnswer = new Label();
            pgAccuracy = new ProgressBar();
            lblAccuracy = new Label();
            label2 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtWord = new TextBox();
            timer2 = new System.Windows.Forms.Timer(components);
            statusStrip1 = new StatusStrip();
            pgStamina = new ToolStripProgressBar();
            lblPoint = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 276);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(222, 23);
            textBox1.TabIndex = 1;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(70, 26);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(222, 214);
            listBox1.TabIndex = 2;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // RightAnswer
            // 
            RightAnswer.AutoSize = true;
            RightAnswer.Font = new Font("맑은 고딕", 18F);
            RightAnswer.ForeColor = SystemColors.HotTrack;
            RightAnswer.Location = new Point(70, 323);
            RightAnswer.Name = "RightAnswer";
            RightAnswer.Size = new Size(27, 32);
            RightAnswer.TabIndex = 3;
            RightAnswer.Text = "0";
            // 
            // WrongAnswer
            // 
            WrongAnswer.AutoSize = true;
            WrongAnswer.Font = new Font("맑은 고딕", 18F);
            WrongAnswer.ForeColor = SystemColors.Desktop;
            WrongAnswer.Location = new Point(214, 323);
            WrongAnswer.Name = "WrongAnswer";
            WrongAnswer.Size = new Size(27, 32);
            WrongAnswer.TabIndex = 4;
            WrongAnswer.Text = "0";
            // 
            // pgAccuracy
            // 
            pgAccuracy.Location = new Point(70, 378);
            pgAccuracy.Name = "pgAccuracy";
            pgAccuracy.Size = new Size(222, 23);
            pgAccuracy.TabIndex = 5;
            // 
            // lblAccuracy
            // 
            lblAccuracy.AutoSize = true;
            lblAccuracy.Font = new Font("맑은 고딕", 14F);
            lblAccuracy.Location = new Point(10, 378);
            lblAccuracy.Name = "lblAccuracy";
            lblAccuracy.Size = new Size(58, 25);
            lblAccuracy.TabIndex = 6;
            lblAccuracy.Text = "100%";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(377, 279);
            label2.Name = "label2";
            label2.Size = new Size(378, 41);
            label2.TabIndex = 8;
            label2.Text = "label2";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtWord
            // 
            txtWord.Location = new Point(377, 348);
            txtWord.Name = "txtWord";
            txtWord.Size = new Size(378, 23);
            txtWord.TabIndex = 10;
            txtWord.KeyDown += txtWord_KeyDown;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { pgStamina, lblPoint });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // pgStamina
            // 
            pgStamina.Margin = new Padding(500, 3, 1, 3);
            pgStamina.Maximum = 3;
            pgStamina.Name = "pgStamina";
            pgStamina.Overflow = ToolStripItemOverflow.Always;
            pgStamina.Size = new Size(100, 16);
            pgStamina.Step = 1;
            pgStamina.Value = 3;
            // 
            // lblPoint
            // 
            lblPoint.Name = "lblPoint";
            lblPoint.Size = new Size(14, 17);
            lblPoint.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(txtWord);
            Controls.Add(label2);
            Controls.Add(lblAccuracy);
            Controls.Add(pgAccuracy);
            Controls.Add(WrongAnswer);
            Controls.Add(RightAnswer);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private Label RightAnswer;
        private Label WrongAnswer;
        private ProgressBar pgAccuracy;
        private Label lblAccuracy;
        private Label label2;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtWord;
        private System.Windows.Forms.Timer timer2;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar pgStamina;
        private ToolStripStatusLabel lblPoint;
    }
}
