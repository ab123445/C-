namespace ChattingClient
{
    partial class Login
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
            txtBoxName = new TextBox();
            LoginBtn = new Button();
            SuspendLayout();
            // 
            // txtBoxName
            // 
            txtBoxName.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txtBoxName.Location = new Point(81, 118);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(318, 33);
            txtBoxName.TabIndex = 0;
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(81, 157);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(318, 23);
            LoginBtn.TabIndex = 1;
            LoginBtn.Text = "이름 만들기";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 311);
            Controls.Add(LoginBtn);
            Controls.Add(txtBoxName);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxName;
        private Button LoginBtn;
    }
}