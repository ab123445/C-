using System.Net;
using System.Net.Sockets;
using System.Text;

namespace sockclient
{
    public partial class Form1 : Form
    {
        string sendText;
        MyClientSocket client = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(() => client.start()));
            t1.IsBackground = true;
            t1.Start();
        }

        public void sendToMainThread(string s)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => sendToMainThread(s)));
                return;
            }
            setListBox(s);
        }

        void setListBox(string data)
        {
            ConsoleListBox.Items.Add(data);
        }

        private void SenderBtn_Click(object sender, EventArgs e)
        {
            if (SenderTxtBox.Text != "")
            {
                sendText = SenderTxtBox.Text;
                SenderTxtBox.Text = "";

                // [상황 2] 우리가 Q로 연결을 끊었을 때
                if (sendText == "Q")
                {
                    setListBox("[System] 'Q'를 입력하여 연결을 종료합니다.");
                    client.SetConnecting(false);
                    client.clientclose(); // 소켓을 확실히 닫아 수신 루프를 탈출시킵니다.
                    return;
                }

                byte[] buff = Encoding.UTF8.GetBytes(sendText);
                client.socksend(buff);
                setListBox(sendText);
            }
        }
    }
}