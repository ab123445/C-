namespace TrayMessage
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
            txtMsg = new TextBox();
            btnMsg = new Button();
            SuspendLayout();
            // 
            // txtMsg
            // 
            txtMsg.Location = new Point(347, 192);
            txtMsg.Name = "txtMsg";
            txtMsg.Size = new Size(100, 23);
            txtMsg.TabIndex = 0;
            // 
            // btnMsg
            // 
            btnMsg.Location = new Point(359, 250);
            btnMsg.Name = "btnMsg";
            btnMsg.Size = new Size(75, 23);
            btnMsg.TabIndex = 1;
            btnMsg.Text = "보이기";
            btnMsg.UseVisualStyleBackColor = true;
            btnMsg.Click += btnMsg_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMsg);
            Controls.Add(txtMsg);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "트레이 메시지";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMsg;
        private Button btnMsg;
    }
}
