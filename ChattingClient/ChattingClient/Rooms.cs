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
        FormBase formBase;
        public Rooms()
        {
            InitializeComponent();
        }

        private void BtnRoom1_Click(object sender, EventArgs e)
        {
            formBase.Close();
            formBase = new(name, 1);
            formBase.Show();
        }

        private void BtnRoom2_Click(object sender, EventArgs e)
        {
            formBase.Close();
            formBase = new(name, 2);
            formBase.Show();
        }

        private void BtnRoom3_Click(object sender, EventArgs e)
        {
            formBase.Close();
            formBase = new(name, 3);
            formBase.Show();
        }


        private void Rooms_Load(object sender, EventArgs e)
        {
            Login login = new();
            login.ShowDialog();
            name = login.getName();
            formBase = new(name, 1);
            formBase.Show();
        }
    }
}
