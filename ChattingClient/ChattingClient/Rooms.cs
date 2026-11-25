using Google.Protobuf.WellKnownTypes;
using MineSearch;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1;

namespace ChattingClient
{
    public partial class Rooms : Form
    {
        //ClientSocket client = new();
        string name = "";
        Dictionary<int, FormChat> formChats = new();
        ClientSocket client;
        public Rooms()
        {
            InitializeComponent();
        }

        private void BtnRoom1_Click(object sender, EventArgs e)
        {
            LoadChatData(1);
            FormChat formBase = new(client, name, 1);

            //Thread t1 = new Thread(() => LoadChatData(1,formBase.loadChatdata_room));
            //t1.Start();

            //formBase.Close();
            formChats.Add(1, formBase);
            formBase.Show();
        }

        private void BtnRoom2_Click(object sender, EventArgs e)
        {
            LoadChatData(2);
            FormChat formBase = new(client, name, 2);

            //Thread t1 = new Thread(() => LoadChatData(2,formBase.loadChatdata_room));
            //t1.Start();
            formChats.Add(2, formBase);
            formBase.Show();
            
        }

        private void BtnRoom3_Click(object sender, EventArgs e)
        {
            LoadChatData(3);
            FormChat formBase = new(client, name, 3);
            //Thread t1 = new Thread(() => LoadChatData(3,formBase.loadChatdata_room));
            //t1.Start();
            formChats.Add(3, formBase);
            formBase.Show();
            
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            client = new();
            Login login = new();
            login.ShowDialog();
            name = login.getName();
            client.start();
            Thread t1 = new Thread(new ThreadStart(() => client.work())); //여기있는 클라이언트 start 지워야 함
            t1.IsBackground = true;
            t1.Start();
        }


        //public async void LoadChatData(int roomNumber, Action<string> action)
        //{
        //    client.socksend($"/load {roomNumber}");


        //    string s = null;
        //    action(s);
        //}


        public async void LoadChatData(int roomNumber)
        {
            client.socksend($"/load {roomNumber}");
        }

        public void LoadChatData_finish(string command, string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => LoadChatData_finish(command, data)));
                return;
            }
            //
            //
           int chatnum = int.Parse(data.Split(" ")[0]);
            FormChat fc = formChats[chatnum];
            fc.loadChatdata_room(data);

            //formChats.Add(3, formBase);
            //action(s);
        }
    }
}
