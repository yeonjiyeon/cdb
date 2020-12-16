using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Customer : System.Web.UI.Page
    {
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\source\repos\MyTable.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = connString;
            sConn.Open();
            sCmd.Connection = sConn;
        }

        public void intoDBData(string id, string name, string phone, string pwd)
        {
            sCmd.CommandText = $"insert into Custom values('{id}','{name}','{phone}','{pwd}')";
            sCmd.ExecuteNonQuery();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id=TextBox1.Text;
            string name = TextBox2.Text;
            string phone = TextBox3.Text;
            string pwd = TextBox4.Text;

            // intoDBData(id,name,phone,pwd);
            sCmd.CommandText = $"insert into Custom values('{id}','{name}','{phone}','{pwd}')";
            sCmd.ExecuteNonQuery();
            lblConfirm.Text = "가입을 축하합니다";
            Button2.Visible = true;
        }


    }
}