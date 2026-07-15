using System.Net;
using System.Net.Sockets;
using System.Text;

namespace sockclient
{
    public partial class Form1 : Form
    {
        string sendText;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MyClientSocket client = new();
            client.start();
        }

        private void SenderBtn_Click(object sender, EventArgs e)
        {
            if (SenderTxtBox.Text != null)
            {
                sendText = SenderTxtBox.Text;
                SenderTxtBox.Text = null;
                //이곳에서 sendText를 buff로 넘겨야함
            }
        }

        public void sendToMainThread(string s)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => sendToMainThread(s)));
                return;
            }
            setListBox(s);
        }

        void setListBox(string data)
        {

        }


        //public string get_sendText()
        //{
        //    if 
        //    return sendText;
        //}
    }
}
