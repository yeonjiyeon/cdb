using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class frmclient : Form
    {
        public frmclient()
        {
            InitializeComponent();
        }

        Socket _Sock;
        private void mnustart_Click(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(tbinterval.Text);
            timer1.Enabled = true;
        }


        private void mnuend_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }


        private void mnuclose_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            string s1 = tbcode.Text;    //10001 :5자리
            string s2 = tbmodel.Text;   //
            string s3 = tbtemp.Text;    //10.5  :5자리
            string s4 = tbhum.Text;     //30.00 :5자리
            string s5 = tbwind.Text;    //05.70 :5자리
            string s6 = dateTimePicker1.Text;   //2020년 10월 어느날 00:..............
            //프로토콜 정의 : [STX:02][s1:05][s2:05][s3:05][s4:05][s5:05][ETX:03]
        }







        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void controlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
