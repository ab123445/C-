using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace socksrv
{
    class Program
    {
        static void Main(string[] args)
        {
            Program server = new Program();
            server.start();
        }

        Socket serverSock;
        Dictionary<int, Socket> clientSocks = new();
        static int client_number = 1;
        void start()
        {
            // (1) 소켓 객체 생성 (TCP 소켓)
            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // (2) 포트에 바인드
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 7000);
            serverSock.Bind(ep);

            // (3) 포트 Listening 시작
            serverSock.Listen(10);

            while (true)
            {
                try
                {
                    // (4) 연결을 받아들여 새 소켓 생성 (하나의 연결만 받아들임)
                    Socket clientSock = serverSock.Accept();

                    int num = client_number;      // 현재 번호를 따로 저장
                    clientSocks.Add(num, clientSock);

                    Thread t1 = new Thread(() => sockrecv(num));
                    t1.Start();

                    client_number++;
                }
                catch
                {
                    break;
                }
            }
            //severSock close
            serverclose();
        }

        void commandsRecv(int num, string data)
        {
            string[] command = data.Split(' ');
            //if (command[0] == "/echo")
            //{
            //    socksend(num, data);
            //}
            if (command[0] == "/tell")
            {
                socksend(int.Parse(command[1]), data);
            }
            Console.WriteLine(data);
        }

        void sockrecv(int num)
        {
            Socket clientSock = clientSocks[num];
            byte[] buff = new byte[8192];

            //Init
            socksend(num, $"/Init {num}\n");
            // 새 클라이언트에게 기존 클라이언트 버튼 생성
            foreach (int i in clientSocks.Keys)
            {
                if (i != num)
                {
                    socksend(num, $"/makeBtn {i}\n");
                }
            }

            // 기존 클라이언트들에게 새 클라이언트 버튼 생성
            foreach (int i in clientSocks.Keys)
            {
                if (i != num)
                {
                    socksend(i, $"/makeBtn {num}\n");
                }
            }


            while (true)
            {
                try
                {
                    int n = clientSock.Receive(buff);
                    string data = Encoding.UTF8.GetString(buff, 0, n);
                    Thread t1 = new Thread(new ThreadStart(() => commandsRecv(num, data)));
                    t1.Start();
                }
                catch
                {
                    break;
                }
            }
            // (7) client 소켓 닫기, 기존 클라이언트들이 가지고 있던 버튼 지우기
            foreach (int i in clientSocks.Keys)
            {
                if (i != num)
                {
                    socksend(i, $"/RemoveBtn {num}\n");
                }
            }
            clientclose(num);
        }

        //send()
        void socksend(int num, string data)
        {
            byte[] buff = Encoding.UTF8.GetBytes(data);
            clientSocks[num].Send(buff, SocketFlags.None);
        }

        //close()
        void serverclose()
        {
            serverSock.Close();
        }
        void clientclose(int i)
        {
            clientSocks[i].Close();
            clientSocks.Remove(i);
        }
    }
}