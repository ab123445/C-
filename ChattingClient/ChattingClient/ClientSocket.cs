using ChattingClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WinFormsApp1;

namespace MineSearch
{
    public class ClientSocket
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //Form form1; // 선언만 위로 빼고, 대입은 start() 안에서 합니다.
        bool connecting = false;
        public int ClientCode;
        bool isLocal = false;
        
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
                isLocal = true;
            }

            
        }

        public void work()
        {
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
            if (isLocal == false)
            {
                byte[] buff = Encoding.UTF8.GetBytes(data);
                if (sock.Connected) sock.Send(buff, SocketFlags.None);
            }
            else
            {

            }
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
            FormChat form1 = Application.OpenForms["FormChat"] as FormChat;
            if (form1 == null) return false;
            form1.sendToMainThread(command, data);
            return true;
        }

        public bool SendToRoom(string command, string data)
        {
            Rooms room = Application.OpenForms["Rooms"] as Rooms;
            if (room == null) return false;
            //room.sendToMainThread(command, data);
            room.LoadChatData_finish(command, data);
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
                        for (int i = 1; i < command.Length; i++) //room name text text text
                        {
                            content += command[i] + " ";
                        }
                        SendMsg("/tell", content);
                    }
                    if (command[0] == "/load")
                    {
                        string content = "";
                        for (int i = 1; i < command.Length; i++) //room name nowdate text text text
                        {
                            content += command[i] + " ";
                        }
                        SendToRoom("/load", content);
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
