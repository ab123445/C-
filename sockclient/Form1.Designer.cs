namespace sockclient
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
            ConsoleListBox = new ListBox();
            SenderTxtBox = new TextBox();
            SenderBtn = new Button();
            SuspendLayout();
            // 
            // ConsoleListBox
            // 
            ConsoleListBox.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ConsoleListBox.FormattingEnabled = true;
            ConsoleListBox.Location = new Point(12, 42);
            ConsoleListBox.Name = "ConsoleListBox";
            ConsoleListBox.Size = new Size(460, 319);
            ConsoleListBox.TabIndex = 0;
            // 
            // SenderTxtBox
            // 
            SenderTxtBox.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SenderTxtBox.Location = new Point(12, 392);
            SenderTxtBox.Name = "SenderTxtBox";
            SenderTxtBox.Size = new Size(360, 27);
            SenderTxtBox.TabIndex = 1;
            // 
            // SenderBtn
            // 
            SenderBtn.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SenderBtn.Location = new Point(397, 383);
            SenderBtn.Name = "SenderBtn";
            SenderBtn.Size = new Size(75, 66);
            SenderBtn.TabIndex = 2;
            SenderBtn.Text = "send";
            SenderBtn.UseVisualStyleBackColor = true;
            SenderBtn.Click += SenderBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 461);
            Controls.Add(SenderBtn);
            Controls.Add(SenderTxtBox);
            Controls.Add(ConsoleListBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ConsoleListBox;
        private TextBox SenderTxtBox;
        private Button SenderBtn;
    }
}
