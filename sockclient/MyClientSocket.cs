using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace sockclient
{
    //buff를 form1에서받자
    public class MyClientSocket
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public void start()
        {
            // (1) 소켓 객체 생성 (TCP 소켓)


            // (2) 서버에 연결
            var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
            sock.Connect(ep);

            string cmd = string.Empty;
            byte[] receiverBuff = new byte[8192];

            Console.WriteLine("Connected... Enter Q to exit");

            // Q 를 누를 때까지 계속 Echo 실행
            while ((cmd = Console.ReadLine()) != "Q")
            {
                byte[] buff = Encoding.UTF8.GetBytes(cmd);

                // (3) 서버에 데이타 전송
                socksend(sock, buff);

                // (4) 서버에서 데이타 수신
                Console.WriteLine(sockreceive(receiverBuff));
            }

            // (5) 소켓 닫기
            clientclose();
        }
        public void socksend(Socket client, byte[] buff)
        {
            client.Send(buff, SocketFlags.None);
        }
        public void clientclose()
        {
            sock.Close();
        }
        public void sockreceive(byte[] receiverBuff)
        {
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 == null) return;



            int n = sock.Receive(receiverBuff);

            string data = Encoding.UTF8.GetString(receiverBuff, 0, n);
            form1.sendToMainThread(data);
        }
    }
}
