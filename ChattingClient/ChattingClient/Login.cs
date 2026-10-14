using MineSearch;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Nsri;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string Name;

        public string getName()
        {
            return Name;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Name = txtBoxName.Text;
            this.Close();
        }
    }
}
