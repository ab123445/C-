using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WinFormsApp1;

namespace MineSearch
{
    internal class ClientSocket
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //Form form1; // 선언만 위로 빼고, 대입은 start() 안에서 합니다.
        bool connecting = false;
        public int ClientCode;
        
        public void start()
        {
            try
            {
                var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
                sock.Connect(ep);

                SendMsg("/msg", "Connected... Enter Q to exit");
                connecting = true;
            }
            catch (Exception e)
            {
                SendMsg("/msg", $"Connection Failed: {e.Message}");
                return;
            }

            byte[] receiverBuff = new byte[8192];

            while (connecting == true)
            {
                sockreceive(receiverBuff);
            }
            SendMsg("/msg", $"Disconnected.");
            clientclose();
        }

        public void socksend(string data)
        {
            byte[] buff = Encoding.UTF8.GetBytes(data);
            if (sock.Connected) sock.Send(buff, SocketFlags.None);
        }

        public void clientclose()
        {
            connecting = false;
            sock.Close();
        }

        public void SetConnecting(bool a)
        {
            connecting = a;
        }



        public bool SendMsg(string command, string data)
        {
            FormBase form1 = Application.OpenForms["FormBase"] as FormBase;
            if (form1 == null) return false;
            form1.sendToMainThread(command, data);
            return true;
        }

        public void sockreceive(byte[] receiverBuff)
        {

            try
            {
                int n = sock.Receive(receiverBuff);

                string data = Encoding.UTF8.GetString(receiverBuff, 0, n);

                string[] lines = data.Split('\n');

                foreach (string line in lines)
                {
                    if (line == "")
                        continue;

                    string[] command = line.Split(' ');

                    if (command[0] == "/Init")
                    {
                        ClientCode = int.Parse(command[1]);
                    }
                    if (command[0] == "/setName")
                    {
                        SendMsg("/setName", command[1]);
                    }
                    if (command[0] == "/tell")
                    {
                        string content = "";
                        for (int i = 1; i < command.Length - 1; i++) //name text text text
                        {
                            content += " " + command[i];
                        }
                        SendMsg("/tell", content);
                    }
                }
            }
            catch
            {
                if (connecting)
                {
                    connecting = false;
                }
            }
        }
    }
}
