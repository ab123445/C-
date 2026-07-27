using System.Net;
using System.Net.Sockets;
using System.Text;

namespace sockclient
{
    public partial class Form1 : Form
    {
        string sendText;
        MyClientSocket client = new();
        int NowBtnX = 0;
        int NowBtnY = 0;
        Dictionary<int, Button> Buttons = new();
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

        public void sendToMainThread(string command, string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => sendToMainThread(command, data)));
                return;
            }

            if (command == "/msg")
            {
                setListBox(data);
            }
            else if (command == "/makeBtn")
            {
                makeBtn(data);
            }
            else if (command == "/setLabel")
            {
                lblClientCode.Text = data;
            }
            else if (command == "/RemoveBtn")
            {
                RemoveBtn(int.Parse(data));
            }
        }

        void setListBox(string data)
        {
            ConsoleListBox.Items.Add(data);
        }

        public void makeBtn(string str)
        {
            if (NowBtnX == 4)
            {
                NowBtnX = 0;
                NowBtnY += 1;
            }
            Button btn = new Button();
            btn.Text = str;
            btn.Location = new Point(NowBtnX * 85 + 12, 425 + NowBtnY * 30);
            btn.Name = str;
            btn.Size = new Size(75, 23);
            btn.TabIndex = 4;
            btn.Text = str;
            btn.UseVisualStyleBackColor = true;
            this.Controls.Add(btn);
            Buttons.Add(int.Parse(str), btn);
            btn.Click += ClientBtn_Click;
            NowBtnX += 1;
        }

        public void RemoveBtn(int num)
        {
            this.Controls.Remove(Buttons[num]);
            Buttons[num].Dispose();
            Buttons.Remove(num);
        }
        private void ClientBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            int ReceiverCode = int.Parse(btn.Name);

            if (SenderTxtBox.Text != "")
            {
                sendText = SenderTxtBox.Text; // ㄱ ㄴ ㄷ
                SenderTxtBox.Text = "";
                string[] command = sendText.Split(' ');

                string data = $"/tell {ReceiverCode} {sendText} {client.ClientCode}";
                client.socksend(data);
                string content = "";
                for (int i = 0; i < command.Length; i++)
                {
                    content = $"{content} {command[i]}";
                }
                setListBox($"[To. {ReceiverCode}]{content}");
            }
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
                    client.socksend(sendText);
                }
                //else if (command[0] == "/echo")
                //{
                //    string data = $"{sendText} {client.ClientCode}";
                //    client.socksend(data);
                //    string content = "";
                //    for (int i = 2; i < command.Length; i++)
                //    {
                //        content = $"{content} {command[i]}";
                //    }
                //    setListBox($"[To. {command[1]}]{content}");
                //}
                else if (command[0] == "/makebtn")
                {
                    makeBtn(command[1]);
                }
                else
                {
                    client.socksend(sendText);
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