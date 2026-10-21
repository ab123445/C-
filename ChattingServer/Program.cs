using Mysqlx.Crud;
using System;
using System.Data;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using WinFormsApp1;

namespace ChattingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program server = new Program();
            server.start();
        }

        Socket serverSock;
        const int MAX = 2;
        Dictionary<int, Socket> clientSocks = new();
        Dictionary<int, string> clientNames = new();
       
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

        MysqlNetwork net = new();
        private void saveMessage(string text, string sender)
        {
            DateTime dt = DateTime.Now;
            string dtime = dt.ToString("yyyy-MM-dd HH:mm:ss");
            net.sendQueryData_insert_update_delete(
                $"INSERT INTO t_chat (name, text, nowdate) VALUES ('{sender}', '{text}', '{dtime}');");
        }
        private void loadMessage(int num) //where Date(nowdate)='2026-10-19'
        {
            DataTable table =
            net.sendSelectQuery("SELECT * FROM t_chat  LIMIT 1000;");

            foreach (DataRow row in table.Rows)
            {
                string name = row["name"].ToString();
                string text = row["text"].ToString();
                string nowdate = row["nowdate"].ToString();
                //Console.WriteLine(nowdate);
                socksend(num, $"/load {name} {nowdate} {text}\n");
                Console.WriteLine($"/load {name} {nowdate} {text}");
            }
        }
        void commandsRecv(int num, string data)
        {
            string[] command = data.Split(' ');
            if (command[0] == "/setName")
            {
                socksend(num, $"/setName {command[1]}");
                clientNames[num] = command[1];
            }
            if (command[0] == "/tell")
            {
                foreach (int i in clientSocks.Keys)
                {
                    if (i != num)
                    {
                        socksend(i, data);
                    }
                }
            }
            if (command[0] == "/saveMessage")
            {
                saveMessage(command[1], clientNames[num]);
            }
            if (command[0] == "/load") //load 이름 날짜 내용
            {
                loadMessage(num);
            }
            else
            {
                Console.WriteLine(data);
            }
            Console.WriteLine(data);
        }

        void sockrecv(int num)
        {
            Socket clientSock = clientSocks[num];
            byte[] buff = new byte[8192];
            socksend(num, $"/Init {num}\n");
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