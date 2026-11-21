using Google.Protobuf.WellKnownTypes;
using MineSearch;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1;

namespace ChattingClient
{
    public partial class Rooms : Form
    {
        //ClientSocket client = new();
        string name = "";
        Dictionary<int, FormChat> formBases = new();
        ClientSocket client = new();
        public Rooms()
        {
            InitializeComponent();
        }

        private void BtnRoom1_Click(object sender, EventArgs e)
        {
            FormChat formBase = new(client, name, 1);

            Thread t1 = new Thread(() => LoadChatData(formBase.loadChatdata_room));
            t1.Start();

            //formBase.Close();
            formBases.Add(1, formBase);
            formBase.Show();
        }

        private void BtnRoom2_Click(object sender, EventArgs e)
        {
            //formBase.Close();
            FormChat formBase = new(client, name, 2);

            Thread t1 = new Thread(() => LoadChatData(formBase.loadChatdata_room));
            t1.Start();
            formBases.Add(2, formBase);
            formBase.Show();
            
        }

        private void BtnRoom3_Click(object sender, EventArgs e)
        {
            //formBase.Close();
            FormChat formBase = new(client, name, 3);
            Thread t1 = new Thread(() => LoadChatData(formBase.loadChatdata_room));
            t1.Start();
            formBases.Add(3, formBase);
            formBase.Show();
            
        }

        internal void sendToMainThread(string c, string d)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => sendToMainThread(c, d)));
                return;
            }
            if (c == "/load")
            {
                int chatnum = int.Parse(d.Split(" ")[0]);
                formBases[chatnum].LoadMessages(d);
            }
        }
        private void Rooms_Load(object sender, EventArgs e)
        {
            Login login = new();
            login.ShowDialog();
            name = login.getName();
        }


        public async void LoadChatData(Action<string> action)
        {
            string s = null;
            action(s);
        }
    }
}
