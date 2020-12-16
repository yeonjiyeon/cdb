using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Documents\ats.mdf;Integrated Security=True;Connect Timeout=30";
        public Form2()
        {
            InitializeComponent();
        }

        public string GetDBData(string Table, string Field, string KField, string Kvalue)
        {

            sCmd.CommandText = $"Select {Field} from {Table} where {KField}='{Kvalue}'";

            return sCmd.ExecuteScalar().ToString();//select문 처리결과 수신   

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sConn.ConnectionString = connString;
            sConn.Open();
            sCmd.Connection = sConn;
            Form1 dlg = new Form1();
            string sId = textBox1.Text;
            string s1 = GetDBData("TB_ACCNT", "USER_ID", "USER_ID", sId).Trim();
            if (sId == s1)
            {
                dlg.tooltip.Text = "로그인 완료";
                dlg.tooltip.BackColor = Color.Blue;
            }
            else
            {
                dlg.tooltip.Text = "회원가입 정보가 없습니다.먼저 가입해주세요";
                dlg.tooltip.BackColor = Color.Red;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
