using Microsoft.VisualBasic;
using System.Data;

namespace WinFormsApp1
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        internal void sendToMsgBox(string v)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => sendToMsgBox(v)));
                return;
            }
            Settings(v);
        }

        private void Settings(string v)
        {
            MessageBox.Show(v);
        }
        MysqlNetwork net;

        private void SelectUsingAdapter()
        {
            DataTable dt = net.sendSendQuery("SELECT * FROM ranking;");
           
            //name
            foreach (DataRow dataRow in dt.Rows)
            {
                string name = dataRow["name"].ToString();

            }
        }
        //mysql
        private void FormBase_Load(object sender, EventArgs e)
        {
            net = new MysqlNetwork();
            //textBox_query.Text = "SELECT * FROM users;";
            //textBox_query.Text = "SELECT * FROM users;";
            //textBox_query.Text = "SELECT * FROM users;";
            textBox_query.Text = "INSERT INTO `student`.`ranking` (`name`, `point`) VALUES ('변지온', 1200);";
            //textBox_query.Text = "SELECT * FROM ranking;";
            //ShowingMessage("goodbye", "나", 7, 26);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string data = textBox_query.Text;
            ShowingMyMessage(data, 7, 35);
            //SelectUsingAdapter();
        }
        int NowY = 103;
        private void ShowingMessage(string text, string sender, int hour, int minute)
        {
            flowLayoutPanel1.Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 1);
            tableLayoutPanel1.Location = new Point(3, NowY);
            NowY += 50;
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(290, 44);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Location = new Point(3, 22);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 0;
            label1.Text = $"{text}";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = $"{sender}";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 22);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 2;
            label3.Text = $"{hour}:{minute}";
        }
        private void ShowingMyMessage(string text, int hour, int minute)
        {
            flowLayoutPanel1.Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 1);
            tableLayoutPanel1.Location = new Point(3, NowY);
            NowY += 50;
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(290, 44);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Location = new Point(3, 22);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 0;
            label1.Text = $"{text}";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = $"나";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 22);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 2;
            label3.Text = $"{hour}:{minute}";
        }
    }
}
