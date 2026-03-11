namespace Snake0114
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
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            Menu_Point = new ToolStripMenuItem();
            Menu_Record = new ToolStripMenuItem();
            Menu_Restart = new ToolStripMenuItem();
            timer2 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { Menu_Point, Menu_Record, Menu_Restart });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(794, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Point
            // 
            Menu_Point.Alignment = ToolStripItemAlignment.Right;
            Menu_Point.Name = "Menu_Point";
            Menu_Point.Size = new Size(38, 20);
            Menu_Point.Text = "0점";
            // 
            // Menu_Record
            // 
            Menu_Record.Name = "Menu_Record";
            Menu_Record.Size = new Size(71, 20);
            Menu_Record.Text = "최고 기록";
            // 
            // Menu_Restart
            // 
            Menu_Restart.Name = "Menu_Restart";
            Menu_Restart.Size = new Size(55, 20);
            Menu_Restart.Text = "재시작";
            Menu_Restart.Click += Menu_Restart_Click;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSalmon;
            ClientSize = new Size(794, 441);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snake Game";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem Menu_Point;
        private System.Windows.Forms.Timer timer2;
        public MenuStrip menuStrip1;
        private ToolStripMenuItem Menu_Record;
        private ToolStripMenuItem Menu_Restart;
    }
}
