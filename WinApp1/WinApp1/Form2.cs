using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp1
{
    public partial class Form2 : Form
    {
        
        public string a1, a2, a3,a4,a5;//public class 외부에서 참조가능
                                       //private  class 외부에서 참조 불가능

        public int cn1, cn2, cn3, cn4, cn5;//combobox의 현재선택값 보관용

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public Form2()  //Creator
        {
            InitializeComponent();

            //int a;
            //comboBox1.SelectedIndex = a; 지역변수는 자동 초기화X
            
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
           
            comboBox1.SelectedIndex = cn1;
            comboBox2.SelectedIndex = cn2;
            comboBox3.SelectedIndex = cn3;
            comboBox4.SelectedIndex = cn4;
            comboBox5.SelectedIndex = cn5;

        }

        private void button1_Click(object sender, EventArgs e)//okbtn
        {
            a1 = comboBox1.Text;
            a2 = comboBox2.Text;
            a3 = comboBox3.Text;
            a4 = comboBox4.Text;
            a5 = comboBox5.Text;

            cn1 = comboBox1.SelectedIndex;
            cn2 = comboBox2.SelectedIndex;
            cn3 = comboBox3.SelectedIndex;
            cn4 = comboBox4.SelectedIndex;
            cn5 = comboBox5.SelectedIndex;

            //int ai = int.Parse(a4);// 문자를 숫자로 변환해준다
            //double ai2 = double.Parse(a3);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
