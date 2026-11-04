namespace WinFormsApp1
{
    partial class FormBase
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
            button_send1 = new Button();
            textBox_query = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblName = new Label();
            SuspendLayout();
            // 
            // button_send1
            // 
            button_send1.Location = new Point(256, 427);
            button_send1.Name = "button_send1";
            button_send1.Size = new Size(75, 23);
            button_send1.TabIndex = 0;
            button_send1.Text = "보내기";
            button_send1.UseVisualStyleBackColor = true;
            button_send1.Click += button_send_Click;
            // 
            // textBox_query
            // 
            textBox_query.Location = new Point(33, 427);
            textBox_query.Name = "textBox_query";
            textBox_query.Size = new Size(217, 23);
            textBox_query.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(33, 34);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(298, 363);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblName.Location = new Point(33, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 21);
            lblName.TabIndex = 6;
            lblName.Text = "이름";
            // 
            // FormBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 562);
            Controls.Add(lblName);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(textBox_query);
            Controls.Add(button_send1);
            Name = "FormBase";
            Text = "FormBase";
            Load += FormBase_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_send1;
        private TextBox textBox_query;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblName;
    }
}
