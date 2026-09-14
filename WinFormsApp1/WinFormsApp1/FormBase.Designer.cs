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
            button_send = new Button();
            dataGridView1 = new DataGridView();
            textBox_query = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button_send
            // 
            button_send.Location = new Point(566, 271);
            button_send.Name = "button_send";
            button_send.Size = new Size(75, 23);
            button_send.TabIndex = 0;
            button_send.Text = "button1";
            button_send.UseVisualStyleBackColor = true;
            button_send.Click += button_send_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 208);
            dataGridView1.TabIndex = 1;
            // 
            // textBox_query
            // 
            textBox_query.Location = new Point(175, 271);
            textBox_query.Name = "textBox_query";
            textBox_query.Size = new Size(371, 23);
            textBox_query.TabIndex = 2;
            // 
            // FormBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox_query);
            Controls.Add(dataGridView1);
            Controls.Add(button_send);
            Name = "FormBase";
            Text = "FormBase";
            Load += FormBase_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_send;
        private DataGridView dataGridView1;
        private TextBox textBox_query;
    }
}
