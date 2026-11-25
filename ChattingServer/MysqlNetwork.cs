using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WinFormsApp1
{
    public partial class MysqlNetwork
    {
        //private readonly string HOST = "www.pcall.kr";
        private readonly string HOST = "ghdwo.com";
        private readonly string ID = "stu_all";
        //private readonly string PW = "code";
        private readonly string PW = "8600";
        //private readonly string DB = "student";
        private readonly string DB = "stu_all";
        MySqlConnection conn;

        public bool isConnected { get; private set; }
        public MysqlNetwork()
        {
            isConnected = false;
            string strConn = $"Server={HOST};Database={DB};Uid={ID};Pwd={PW};Charset=utf8";

            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();
                isConnected = true;
            }

            catch
            {
                sendError();
            }

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

        public void sendError()
        {
            Console.WriteLine("SQL 서버가 동작하지 않습니다.");
        }

        public long sendQueryData_insert_update_delete(string query)
        {
            lock (conn)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    long data = cmd.ExecuteNonQuery();
                    if (data > 0)
                        data = cmd.LastInsertedId;
                    else
                        return -1;
                    return data;
                }
                catch
                {
                    sendError();
                    return -1;
                }
            }
        }


        //s
        public DataTable sendSelectQuery(string query)
        {
            lock (conn)
            {
                try
                {
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds, DB);
                    foreach (DataTable dt in ds.Tables)
                    {
                        return dt;
                    }
                }
                catch
                {
                    sendError();
                    return null;
                }
                
            }
            return null;
        }

    }
}
