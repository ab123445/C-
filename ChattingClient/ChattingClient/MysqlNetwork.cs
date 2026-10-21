using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WinFormsApp1
{
    public partial class MysqlNetwork
    {
        MySqlConnection conn;

        public bool isConnected { get; private set; }
        public MysqlNetwork()
        {

        }
        ~MysqlNetwork()
        {
            close();
        }
        public void close()
        {
            if (isConnected)
                conn.Close();
        }

        
    }
}
