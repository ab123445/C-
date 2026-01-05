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
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(217, 292);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(222, 23);
            textBox1.TabIndex = 1;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" });
            listBox1.Location = new Point(217, 42);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(222, 214);
            listBox1.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private ListBox listBox1;
    }
}
