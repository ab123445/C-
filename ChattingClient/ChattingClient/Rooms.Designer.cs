namespace ChattingClient
{
    partial class Rooms
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
            this.BtnRoom1 = new Button();
            this.BtnRoom2 = new Button();
            BtnRoom3 = new Button();
            SuspendLayout();
            // 
            // BtnRoom1
            // 
            this.BtnRoom1.Location = new Point(12, 12);
            this.BtnRoom1.Name = "BtnRoom1";
            this.BtnRoom1.Size = new Size(181, 53);
            this.BtnRoom1.TabIndex = 0;
            this.BtnRoom1.Text = "1번 방";
            this.BtnRoom1.UseVisualStyleBackColor = true;
            // 
            // BtnRoom2
            // 
            this.BtnRoom2.Location = new Point(12, 71);
            this.BtnRoom2.Name = "BtnRoom2";
            this.BtnRoom2.Size = new Size(181, 57);
            this.BtnRoom2.TabIndex = 1;
            this.BtnRoom2.Text = "2번 방";
            this.BtnRoom2.UseVisualStyleBackColor = true;
            // 
            // BtnRoom3
            // 
            BtnRoom3.Location = new Point(12, 134);
            BtnRoom3.Name = "BtnRoom3";
            BtnRoom3.Size = new Size(181, 64);
            BtnRoom3.TabIndex = 2;
            BtnRoom3.Text = "3번 방";
            BtnRoom3.UseVisualStyleBackColor = true;
            // 
            // Rooms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(205, 220);
            Controls.Add(BtnRoom3);
            Controls.Add(this.BtnRoom2);
            Controls.Add(this.BtnRoom1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Rooms";
            Text = "Rooms";
            Load += Rooms_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnRoom1;
        private Button BtnRoom2;
        private Button BtnRoom3;
    }
}