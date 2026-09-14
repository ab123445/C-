using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WinFormsApp1
{
    public partial class MysqlNetwork
    {
        private readonly string HOST = "www.pcall.kr";
        private readonly string ID = "stu_all";
        private readonly string PW = "code";
        private readonly string DB = "student";
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
            FormBase form = (FormBase)Application.OpenForms["FormBase"];
            if (form == null) return;
            form.sendToMsgBox("서버가 동작하지 않습니다.");
        }

        public long sendQueryData(string query)
        {
            lock (conn)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                long data = cmd.ExecuteNonQuery();
                if (data > 0)
                    data = cmd.LastInsertedId;
                else
                    return -1;
                return data;
            }
        }
        public DataTable sendSendQuery(string query)
        {
            lock (conn)
            {
                MySqlDataAdapter adpt = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adpt.Fill(ds, DB);
                foreach (DataTable dt in ds.Tables)
                {
                    return dt;
                }
            }
            return null;
        }

    }
}
