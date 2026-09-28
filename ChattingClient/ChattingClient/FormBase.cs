using Microsoft.VisualBasic;
using System.Data;
using System.Drawing.Text;

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
            DataTable dt = net.sendSelectQuery("SELECT * FROM ranking;");

            //name
            foreach (DataRow dataRow in dt.Rows)
            {
                string name = dataRow["name"].ToString();

            }
        }
        // INSERT INTO t_chat (name, text, hour, minute) VALUES ('s0', 'f', 1, 3);
        //mysql
        private void FormBase_Load(object sender, EventArgs e)
        {
            net = new MysqlNetwork();
            //textBox_query.Text = "SELECT * FROM users;";
            //textBox_query.Text = "SELECT * FROM users;";
            //textBox_query.Text = "SELECT * FROM users;";
            //textBox_query.Text = "INSERT INTO `student`.`ranking` (`name`, `point`) VALUES ('변지온', 1200);";
            //textBox_query.Text = "SELECT * FROM ranking;";
        }
        
        private void button_send_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string data = textBox_query.Text;
            ShowingMyMessage(data, dt.Hour, dt.Minute);
            saveMessage(data, "나", dt);

        }
        private void button_send2_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
           // dt.ToLongDateString()
            string data = textBox_query2.Text;
            ShowingMessage(data, "슬기샘", dt.Hour, dt.Minute);
            saveMessage(data, "슬기샘", dt);
        }

        private void saveMessage(string text, string sender, DateTime dt)
        {
            string dtime = dt.ToString("yyyy-MM-dd HH:mm:ss");
            net.sendQueryData_insert_update_delete(
                $"INSERT INTO t_chat (name, text, nowdate) VALUES ('{sender}', '{text}', '{dtime}');");
        }


        private void ShowingMessage(string text, string sender, int hour, int minute)
        {
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            flowLayoutPanel1.Controls.Add(tableLayoutPanel1);
            flowLayoutPanel1.ScrollControlIntoView(tableLayoutPanel1);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 1);
            tableLayoutPanel1.Location = new Point(1, 1);
            tableLayoutPanel1.BackColor = Color.Red;
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
            if (hour > 12)
            {
                label3.Text = $"오후 {hour-12}:{minute}";
            }
            else if (hour == 12)
            {
                label3.Text = $"오후 {hour}:{minute}";
            }
            else
            {
                label3.Text = $"오전 {hour}:{minute}";
            }
        }
        private void ShowingMyMessage(string text, int hour, int minute)
        {
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            flowLayoutPanel1.Controls.Add(tableLayoutPanel1);
            flowLayoutPanel1.ScrollControlIntoView(tableLayoutPanel1);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Location = new Point(1, 1);
            tableLayoutPanel1.BackColor = Color.Aqua;

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
            // UPDATE t_chat SET nowdate='2026-09-28 19:30:39' WHERE  idx=1;
            // UPDATE t_chat SET nowdate=now() WHERE  idx=1;
            // label3
            // INSERT INTO t_chat (name, text, hour, minute) VALUES ('s0', 'f', 1, 3);
            label3.AutoSize = true;
            label3.Location = new Point(148, 22);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 2;
            if (hour > 12)
            {
                label3.Text = $"오후 {hour - 12}:{minute}";
            }
            else if (hour == 12)
            {
                label3.Text = $"오후 {hour}:{minute}";
            }
            else
            {
                label3.Text = $"오전 {hour}:{minute}";
            }


        }


    }
}
