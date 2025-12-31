namespace WinForm1231
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
            grpFont = new GroupBox();
            txtSampleText = new TextBox();
            chkItalic = new CheckBox();
            chkBold = new CheckBox();
            cboFont = new ComboBox();
            lblFont = new Label();
            grpBar = new GroupBox();
            pgDummy = new ProgressBar();
            tbDummy = new TrackBar();
            grpForm = new GroupBox();
            btnMsgBox = new Button();
            btnModaless = new Button();
            btnModal = new Button();
            grpTreeList = new GroupBox();
            lvDummy = new TreeView();
            tvDummy = new TreeView();
            grpFont.SuspendLayout();
            grpBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbDummy).BeginInit();
            grpForm.SuspendLayout();
            grpTreeList.SuspendLayout();
            SuspendLayout();
            // 
            // grpFont
            // 
            grpFont.Controls.Add(txtSampleText);
            grpFont.Controls.Add(chkItalic);
            grpFont.Controls.Add(chkBold);
            grpFont.Controls.Add(cboFont);
            grpFont.Controls.Add(lblFont);
            grpFont.Location = new Point(146, 70);
            grpFont.Name = "grpFont";
            grpFont.Size = new Size(350, 230);
            grpFont.TabIndex = 0;
            grpFont.TabStop = false;
            grpFont.Text = "ComboBox, CheckBox, TextBox";
            // 
            // txtSampleText
            // 
            txtSampleText.Location = new Point(18, 107);
            txtSampleText.Name = "txtSampleText";
            txtSampleText.Size = new Size(100, 23);
            txtSampleText.TabIndex = 5;
            txtSampleText.Text = "Hello, C#";
            // 
            // chkItalic
            // 
            chkItalic.AutoSize = true;
            chkItalic.Location = new Point(240, 42);
            chkItalic.Name = "chkItalic";
            chkItalic.Size = new Size(62, 19);
            chkItalic.TabIndex = 4;
            chkItalic.Text = "이탤릭";
            chkItalic.UseVisualStyleBackColor = true;
            chkItalic.CheckedChanged += chkItalic_CheckedChanged;
            // 
            // chkBold
            // 
            chkBold.AutoSize = true;
            chkBold.Location = new Point(184, 41);
            chkBold.Name = "chkBold";
            chkBold.Size = new Size(50, 19);
            chkBold.TabIndex = 3;
            chkBold.Text = "굵게";
            chkBold.UseVisualStyleBackColor = true;
            chkBold.CheckedChanged += chkBold_checkedChanged;
            // 
            // cboFont
            // 
            cboFont.FormattingEnabled = true;
            cboFont.Location = new Point(41, 38);
            cboFont.Name = "cboFont";
            cboFont.Size = new Size(121, 23);
            cboFont.TabIndex = 1;
            cboFont.SelectedIndexChanged += cboFont_SelectedIndexChanged;
            // 
            // lblFont
            // 
            lblFont.AutoSize = true;
            lblFont.Location = new Point(4, 38);
            lblFont.Name = "lblFont";
            lblFont.Size = new Size(31, 15);
            lblFont.TabIndex = 0;
            lblFont.Text = "Font";
            // 
            // grpBar
            // 
            grpBar.Controls.Add(pgDummy);
            grpBar.Controls.Add(tbDummy);
            grpBar.Location = new Point(146, 309);
            grpBar.Name = "grpBar";
            grpBar.Size = new Size(350, 128);
            grpBar.TabIndex = 1;
            grpBar.TabStop = false;
            grpBar.Text = "TrackBar & ProgressBar";
            // 
            // pgDummy
            // 
            pgDummy.Location = new Point(6, 53);
            pgDummy.Maximum = 20;
            pgDummy.Name = "pgDummy";
            pgDummy.Size = new Size(338, 38);
            pgDummy.TabIndex = 1;
            // 
            // tbDummy
            // 
            tbDummy.Location = new Point(3, 19);
            tbDummy.Maximum = 20;
            tbDummy.Name = "tbDummy";
            tbDummy.Size = new Size(341, 45);
            tbDummy.TabIndex = 0;
            tbDummy.Scroll += tbDummy_Scroll;
            // 
            // grpForm
            // 
            grpForm.Controls.Add(btnMsgBox);
            grpForm.Controls.Add(btnModaless);
            grpForm.Controls.Add(btnModal);
            grpForm.Location = new Point(146, 448);
            grpForm.Name = "grpForm";
            grpForm.Size = new Size(350, 100);
            grpForm.TabIndex = 2;
            grpForm.TabStop = false;
            grpForm.Text = "Modal && Modaless";
            // 
            // btnMsgBox
            // 
            btnMsgBox.Location = new Point(184, 29);
            btnMsgBox.Name = "btnMsgBox";
            btnMsgBox.Size = new Size(160, 66);
            btnMsgBox.TabIndex = 2;
            btnMsgBox.Text = "MessageBox";
            btnMsgBox.UseVisualStyleBackColor = true;
            btnMsgBox.Click += btnMsgBox_Click;
            // 
            // btnModaless
            // 
            btnModaless.Location = new Point(89, 29);
            btnModaless.Name = "btnModaless";
            btnModaless.Size = new Size(89, 65);
            btnModaless.TabIndex = 1;
            btnModaless.Text = "Modaless";
            btnModaless.UseVisualStyleBackColor = true;
            btnModaless.Click += btnModaless_Click;
            // 
            // btnModal
            // 
            btnModal.Location = new Point(8, 29);
            btnModal.Name = "btnModal";
            btnModal.Size = new Size(75, 65);
            btnModal.TabIndex = 0;
            btnModal.Text = "Modal";
            btnModal.UseVisualStyleBackColor = true;
            btnModal.Click += btnModal_Click;
            // 
            // grpTreeList
            // 
            grpTreeList.Controls.Add(lvDummy);
            grpTreeList.Controls.Add(tvDummy);
            grpTreeList.Location = new Point(146, 558);
            grpTreeList.Name = "grpTreeList";
            grpTreeList.Size = new Size(350, 243);
            grpTreeList.TabIndex = 3;
            grpTreeList.TabStop = false;
            grpTreeList.Text = "TreeView && ListView";
            // 
            // lvDummy
            // 
            lvDummy.Location = new Point(184, 22);
            lvDummy.Name = "lvDummy";
            lvDummy.Size = new Size(160, 215);
            lvDummy.TabIndex = 1;
            // 
            // tvDummy
            // 
            tvDummy.Location = new Point(8, 22);
            tvDummy.Name = "tvDummy";
            tvDummy.Size = new Size(170, 215);
            tvDummy.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 891);
            Controls.Add(grpTreeList);
            Controls.Add(grpForm);
            Controls.Add(grpBar);
            Controls.Add(grpFont);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grpFont.ResumeLayout(false);
            grpFont.PerformLayout();
            grpBar.ResumeLayout(false);
            grpBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbDummy).EndInit();
            grpForm.ResumeLayout(false);
            grpTreeList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpFont;
        private TextBox txtSampleText;
        private CheckBox chkItalic;
        private CheckBox chkBold;
        private ComboBox cboFont;
        private Label lblFont;
        private GroupBox grpBar;
        private ProgressBar pgDummy;
        private TrackBar tbDummy;
        private GroupBox grpForm;
        private Button btnMsgBox;
        private Button btnModaless;
        private Button btnModal;
        private GroupBox grpTreeList;
        private TreeView lvDummy;
        private TreeView tvDummy;
    }
}
