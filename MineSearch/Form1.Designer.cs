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
            menuStrip1 = new MenuStrip();
            txtRuleBox = new ToolStripTextBox();
            txtRestartBox = new ToolStripTextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { txtRuleBox, txtRestartBox });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(524, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // txtRuleBox
            // 
            txtRuleBox.BackColor = SystemColors.ActiveBorder;
            txtRuleBox.Name = "txtRuleBox";
            txtRuleBox.ReadOnly = true;
            txtRuleBox.Size = new Size(100, 23);
            txtRuleBox.Text = "규칙";
            txtRuleBox.Click += txtRulebox_Click;
            // 
            // txtRestartBox
            // 
            txtRestartBox.BackColor = SystemColors.ActiveBorder;
            txtRestartBox.Name = "txtRestartBox";
            txtRestartBox.ReadOnly = true;
            txtRestartBox.Size = new Size(100, 23);
            txtRestartBox.Text = "다시하기";
            txtRestartBox.Click += txtRestartBox_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 501);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripTextBox txtRuleBox;
        private ToolStripTextBox txtRestartBox;
    }
}
