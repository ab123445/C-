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
                string[] command = sendText.Split(' ');
                // [상황 2] 우리가 Q로 연결을 끊었을 때
                if (sendText == "Q")
                {
                    setListBox("Client lost connection.");
                    client.SetConnecting(false);
                    client.clientclose(); // 소켓을 확실히 닫아 수신 루프를 탈출시킵니다.
                    return;
                }
                else if (command[0] == "/client")
                {
                    //lblClientCode.Text = parts[1];
                    byte[] buff = Encoding.UTF8.GetBytes(sendText);
                    client.socksend(buff);
                }
                else if (command[0] == "/echo")
                {

                    byte[] buff = Encoding.UTF8.GetBytes(sendText);
                    byte[] senderInfo = Encoding.UTF8.GetBytes(
                        $"/senderInfo {client.ClientCode}");
                    client.socksend(senderInfo);
                    client.socksend(buff);
                    setListBox($"[To. {command[1]}] {command[2]}");
                }
                else
                {
                    byte[] buff = Encoding.UTF8.GetBytes(sendText);
                    client.socksend(buff);
                    setListBox($"[To. Server] {sendText}");
                }

            }
        }
        public void setLabel(int s)
        {
            lblClientCode.Text = s.ToString();
        }
    }
}