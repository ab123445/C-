using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MineSearch
{
    internal class ClientSocket
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Form1 form1; // 선언만 위로 빼고, 대입은 start() 안에서 합니다.
        bool connecting = false;
        public int ClientCode;

        public void start()
        {
            form1 = Application.OpenForms["Form1"] as Form1;

            try
            {
                var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
                sock.Connect(ep);

                form1?.sendToMainThread("/msg", "Connected... Enter Q to exit");
                connecting = true;
            }
            catch (Exception e)
            {
                form1?.sendToMainThread("/msg", $"Connection Failed: {e.Message}");
                return;
            }

            byte[] receiverBuff = new byte[8192];

            while (connecting == true)
            {
                sockreceive(receiverBuff);
            }
            form1?.sendToMainThread("/msg", $"Disconnected.");
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

        public void sockreceive(byte[] receiverBuff)
        {
            if (form1 == null) return;

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
                        form1.sendToMainThread("/msg", $"Your code is {ClientCode}.\n");
                        form1.sendToMainThread("/setText", ClientCode.ToString());
                    }
                    if (command[0] == "/join")
                    {
                        form1.sendToMainThread("/msg", $"{command[1]} entered the waiting room.\n");
                    }
                    if (command[0] == "/matchConnect")
                    {
                        form1.sendToMainThread("/msg", "Match started!\n");
                        form1.sendToMainThread("/matchStart", $"{command[1]}");
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
