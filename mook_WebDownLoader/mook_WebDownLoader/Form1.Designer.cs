using System.Net;

namespace mook_WebDownLoader
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
            lblUrl = new Label();
            txtUrl = new TextBox();
            btnDown = new Button();
            btnFolder = new Button();
            cbOpen = new CheckBox();
            pgbDownload = new ProgressBar();
            fbdFile = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblUrl.Location = new Point(12, 9);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(42, 21);
            lblUrl.TabIndex = 0;
            lblUrl.Text = "주소";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(60, 7);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(466, 23);
            txtUrl.TabIndex = 1;
            // 
            // btnDown
            // 
            btnDown.Enabled = false;
            btnDown.Location = new Point(541, 7);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(75, 23);
            btnDown.TabIndex = 2;
            btnDown.Text = "다운로드";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnFolder
            // 
            btnFolder.Location = new Point(622, 7);
            btnFolder.Name = "btnFolder";
            btnFolder.Size = new Size(75, 23);
            btnFolder.TabIndex = 3;
            btnFolder.Text = "폴 더";
            btnFolder.UseVisualStyleBackColor = true;
            btnFolder.Click += btnFolder_Click;
            // 
            // cbOpen
            // 
            cbOpen.AutoSize = true;
            cbOpen.Location = new Point(703, 9);
            cbOpen.Name = "cbOpen";
            cbOpen.Size = new Size(66, 19);
            cbOpen.TabIndex = 4;
            cbOpen.Text = "창 열기";
            cbOpen.UseVisualStyleBackColor = true;
            // 
            // pgbDownload
            // 
            pgbDownload.Location = new Point(12, 36);
            pgbDownload.Name = "pgbDownload";
            pgbDownload.Size = new Size(757, 23);
            pgbDownload.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 148);
            Controls.Add(pgbDownload);
            Controls.Add(cbOpen);
            Controls.Add(btnFolder);
            Controls.Add(btnDown);
            Controls.Add(txtUrl);
            Controls.Add(lblUrl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "웹 다운로드";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUrl;
        private TextBox txtUrl;
        private Button btnDown;
        private Button btnFolder;
        private CheckBox cbOpen;
        private ProgressBar pgbDownload;
        private FolderBrowserDialog fbdFile;
    }
}
