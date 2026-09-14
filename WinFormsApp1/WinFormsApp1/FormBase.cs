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
            dataGridView1.DataSource = dt;
        }
        //mysql
        private void FormBase_Load(object sender, EventArgs e)
        {
            net = new MysqlNetwork();
            //textBox_query.Text = "SELECT * FROM users;";
            //textBox_query.Text = "SELECT * FROM users;";
            //textBox_query.Text = "SELECT * FROM users;";
            textBox_query.Text = "INSERT INTO `student`.`ranking` (`name`, `point`) VALUES ('º¯Áö¿Â', 1200);";
            //textBox_query.Text = "SELECT * FROM ranking;";
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string data = textBox_query.Text;

            SelectUsingAdapter();
        }
    }
}
