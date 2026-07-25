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
                    clientSocks.Add(client_number, clientSock);

                    Thread t1 = new Thread(new ThreadStart(() => sockrecv(client_number)));
                    t1.Start();
                    client_number += 1;
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
            if (command[0] == "/client")
            {

                socksend(num, $"/SetClient {command[1]}");
                clientSocks[int.Parse(command[1])] = clientSocks[num];

            }
            if (command[0] == "/echo")
            {
                foreach (int i in clientSocks.Keys)
                {
                    if (int.Parse(command[1]) == i)
                    {
                        socksend(i, data);
                    }
                }

            }

            Console.WriteLine(data);
        }

        void sockrecv(int num)
        {
            Socket clientSock = clientSocks[num];
            byte[] buff = new byte[8192];

            //클라이언트 번호 주기
            socksend(num, $"/SetClient {num}");
            //나에게 원래 있던 클라이언트들 버튼 생성
            socksend(num, $"/makeBtn {num}");
            //주변 클라이언트들에게 내 버튼 생성



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
            // (7) client 소켓 닫기
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