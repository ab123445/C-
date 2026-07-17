using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms; // Application을 쓰기 위해 유지

namespace sockclient
{
    public class MyClientSocket
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Form1 form1; // 선언만 위로 빼고, 대입은 start() 안에서 합니다.
        bool connecting = false;

        public void start()
        {
            form1 = Application.OpenForms["Form1"] as Form1;

            try
            {
                var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
                sock.Connect(ep);

                form1?.sendToMainThread("Connected... Enter Q to exit");
                connecting = true;
            }
            catch (Exception ex)
            {
                form1?.sendToMainThread($"Connection Failed: {ex.Message}");
                return;
            }

            byte[] receiverBuff = new byte[8192];

            while (connecting == true)
            {
                sockreceive(receiverBuff);
            }
            form1?.sendToMainThread($"Disconnected.");
            clientclose();
        }

        public void socksend(byte[] buff)
        {
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

                if (n == 0)
                {
                    connecting = false;
                    form1.sendToMainThread("Server disconnected.");
                    return;
                }

                string data = Encoding.UTF8.GetString(receiverBuff, 0, n);
                form1.sendToMainThread($"Server: {data}");
            }
            catch
            {
                // 서버가 비정상 종료(강제 종료) 되었을 때 예외 처리
                if (connecting)
                {
                    connecting = false;
                    form1.sendToMainThread("Server lost connection broken.");
                }
            }
        }
    }
}
