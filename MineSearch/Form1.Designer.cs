namespace MineSearch
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            time_txtbox = new ToolStripTextBox();
            RestartButton = new ToolStripMenuItem();
            RuleButton = new ToolStripMenuItem();
            count_txtbox = new ToolStripTextBox();
            difficultybutton = new ToolStripMenuItem();
            WaitingBtn = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            ConsoleListBox = new ListBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { time_txtbox, RestartButton, RuleButton, count_txtbox, difficultybutton, WaitingBtn });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(704, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // time_txtbox
            // 
            time_txtbox.Alignment = ToolStripItemAlignment.Right;
            time_txtbox.BackColor = Color.FromArgb(224, 224, 224);
            time_txtbox.Margin = new Padding(0, 0, 1, 0);
            time_txtbox.Name = "time_txtbox";
            time_txtbox.Size = new Size(100, 23);
            // 
            // RestartButton
            // 
            RestartButton.BackColor = Color.FromArgb(224, 224, 224);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(55, 23);
            RestartButton.Text = "재시작";
            RestartButton.Click += RestartButton_Click;
            // 
            // RuleButton
            // 
            RuleButton.BackColor = Color.FromArgb(224, 224, 224);
            RuleButton.Margin = new Padding(10, 0, 0, 0);
            RuleButton.Name = "RuleButton";
            RuleButton.Size = new Size(43, 23);
            RuleButton.Text = "규칙";
            RuleButton.Click += RuleButton_Click;
            // 
            // count_txtbox
            // 
            count_txtbox.Alignment = ToolStripItemAlignment.Right;
            count_txtbox.BackColor = Color.FromArgb(224, 224, 224);
            count_txtbox.Name = "count_txtbox";
            count_txtbox.Size = new Size(100, 23);
            // 
            // difficultybutton
            // 
            difficultybutton.BackColor = Color.FromArgb(224, 224, 224);
            difficultybutton.Margin = new Padding(10, 0, 0, 0);
            difficultybutton.Name = "difficultybutton";
            difficultybutton.Size = new Size(83, 23);
            difficultybutton.Text = "난이도 조절";
            difficultybutton.Click += difficultybutton_Click;
            // 
            // WaitingBtn
            // 
            WaitingBtn.BackColor = Color.FromArgb(224, 224, 224);
            WaitingBtn.Margin = new Padding(10, 0, 0, 0);
            WaitingBtn.Name = "WaitingBtn";
            WaitingBtn.Size = new Size(107, 23);
            WaitingBtn.Text = "대기실 입장하기";
            WaitingBtn.Click += WaitingBtn_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // ConsoleListBox
            // 
            ConsoleListBox.FormattingEnabled = true;
            ConsoleListBox.Location = new Point(430, 40);
            ConsoleListBox.Name = "ConsoleListBox";
            ConsoleListBox.Size = new Size(160, 394);
            ConsoleListBox.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 501);
            Controls.Add(ConsoleListBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "지뢰찾기";
            Load += Form1_Load;
            MouseClick += Form1_MouseClick;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripTextBox time_txtbox;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem RestartButton;
        private ToolStripMenuItem RuleButton;
        private ToolStripTextBox count_txtbox;
        private ToolStripMenuItem difficultybutton;
        private ListBox ConsoleListBox;
        private ToolStripMenuItem WaitingBtn;
    }
}
