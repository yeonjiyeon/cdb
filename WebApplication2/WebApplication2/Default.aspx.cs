using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
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
    

        public string GetDBData(string Table, string Field, string KField, string Kvalue)
        {

            sCmd.CommandText = $"Select {Field} from {Table} where {KField}='{Kvalue}'";

            return sCmd.ExecuteScalar().ToString();//select문 처리결과 수신   
            
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sName = tbUserName.Text;
            string spwd = tbPassword.Text;

            string s1 = GetDBData("Custom","pwd","name",sName).Trim();
            if (spwd == s1)
            {
                lblCong.Text = $"{sName}님, 반갑습니다.";
            }
            else { lblCong.Text = $"회원가입 정보가 없습니다.먼저 가입해주세요"; }

        }

        protected void tbUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}