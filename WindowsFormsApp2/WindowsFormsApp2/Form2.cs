using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string sRet;
        private void button1_Click(object sender, EventArgs e)
        {//int cn1, cn2, cn3,....
            sRet = comboBox1.Text + " " +
                   comboBox2.Text + " " +
                   comboBox3.Text + " " +
                   comboBox4.Text + " " +
                   comboBox5.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
