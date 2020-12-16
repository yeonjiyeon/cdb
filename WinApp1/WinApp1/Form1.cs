using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp1
{
    public partial class FormTest1 : Form
    {
        
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string key, string def, StringBuilder sb, int size, string path);
       
        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string Section, string key, string val, string path);

        public FormTest1() //생성자
        {
            InitializeComponent();
           // rbOPtion1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = textBox1.Text;
           // String str = textBox1.Text.Replace("hulklee","집으로가자");
            //label1.Text = str;
            //textBox1.Text = label1.Text;


            //checkbox 값 체크에 따른 변화
            /*if (checkBox1.Checked) {// bool값으로 나타내야 한다 checkBox1.Checked = true 랑 같음,//소문자로 바꾸어서 출력
                //str = textBox1.Text.ToLower();
                label1.Text = str;
                str = textBox1.Text.Replace("hulklee", "집으로가자");
                label1.Text = str;
                /* } else if(checkBox2.Checked) {
                     str = textBox1.Text.ToUpper();
                     label2.Text = str;
            */

            //라디오 버튼 체크에 따른 변화
                if (rbOPtion1.Checked){
                 str = textBox1.Text.ToLower();
                 label1.Text = str;
                    

                  }else if(rboption2.Checked) {
                         str = textBox1.Text.ToUpper();
                         label2.Text = str;
                }
         
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        string sStr;
        //함수명의 일반화 GetToken 인수로 주어진 문자열에 대하여 
        //주어진 구분자로 구분되는 필드의 n번째 데이터를 추출하여 되돌려 주는 일반 함수
        //함수(argument)의 인수로는 string.str, string seperator, int field_index(필드의 위치)
        //str 대상문자열
        //seperator 구분자
        //field_index : 구분자로 구분되는 필드 번호
        //return: string sRet
        //        sRet : 추출된 문자데이터
        //해당하는 데이터가 없을 경우 --(빈 문자열)을 반환
        //error 발생가능한 에러는 ??

        public string GetToken(string str, string sep, int n) {
            /*
             string ss = GetToken(sStr,",",3);
             
            int n = sStr.IndexOf(",");//첫번째 구분자
            int n1 = sStr.IndexOf(",", n + 1);//두번째 구분자
            int n2 = sStr.IndexOf(",",n1+1);
            int len = n1 - n - 1;
            int len2 = n2 - n1 - 1;
            string s1 = sStr.Substring(n + 1, len);
            int len = sStr.Length;*/

            //for loop를 사용하여 n번째 구분자를 탐색
            //str = "0kim,1lee,2han,3seo,4cho,5cha", sep="," n = 3 (zero base)
            //ret = "3seo"
            //n번째 구분자 이후 n+1번째 구분자 탐색
            //문자열 길이 계산  int len = sStr.Length;
            //문자열 추출 :Substring 메서드 이용
            int i; //local index
            int n1=0, n2, n3; // temp int var 
            string ss;


            for (i = 0; i < n; i++) {//시작 i = 0, 종료 i = n for 루프의 임계값(경계값)
                
                n1 = str.IndexOf(sep, n1)+1;//i째 구분자
                                            // n1: i 번째 필드시작점
                                            // indexOf : 문자가 없을 경우 -1
                if (n1 == 0) return "";                              
            }//for
            n2 = str.IndexOf(sep, n1);//n+1번째 구분자
                                      //if (n2 <= n1) return "";
            if (n2 == -1) n2 = str.Length;
            n3 = n2 - n1; //문자열 길이 계산 
            ss = str.Substring(n1, n3);
            return ss;

        }//GetToken

        int cn1, cn2, cn3, cn4, cn5;//폼2의 콤보박스 설정값 보관용
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();

            dlg.cn1 = cn1;
            dlg.cn2 = cn2;
            dlg.cn3 = cn3;
            dlg.cn4 = cn4;
            dlg.cn5 = cn5;


            DialogResult dr =dlg.ShowDialog();
            if (dr == DialogResult.OK) {//ok--> 1과 같다
                cn1 = dlg.cn1;
                cn2 = dlg.cn2;
                cn3 = dlg.cn3;
                cn4 = dlg.cn4;
                cn5 = dlg.cn5;

                //string str = string.Format("{0} {1} {2} {3} ~~",dlg.a1, dlg.a2, dlg.a3, dlg.a4);           
                sStr = string.Format("{0},{1},{2},{3},{4}, ~~", dlg.a1, dlg.a2, dlg.a3, dlg.a4,dlg.a5);
                MessageBox.Show(sStr);
                tbTest.Text = sStr;
                btnNoop.Text = "Ready";
            }//if
        }

        private void TextBox2_TextChanged_1(object sender, EventArgs e)
        {
            /*
            int sss = int.Parse(tbTest.Text); 
            tbTest2.Text = string.Format("{0:X}", sss);*/

            //char a = str[0];// 문자열 str의 첫번째 문자, char로 받아서 바이트로 바꿔야함 바로 안됨
            //byte c = (byte)a; //byte : 1byte int
            //tbTest2.Text = string.Format("{0:d}", c);

            string str = tbTest.Text;
            int len = str.Length;
            int i;
            string s4 = textBox2.Text;
            int s5 = int.Parse(s4);

            StringBuilder sb = new StringBuilder();

            tbTest2.Text = "";
            for (i=0; i<len; i++) {
                char a = str[i];
                byte c = (byte)a;
                //i != 0 && i % s5 == 0
                sb.Append($" {c:X2}");
                if((i+1) % s5 == 0) { //i !=0 && i % s5 ==0
                    sb.Append("\r\n");
                }
               // tbTest2.Text += string.Format(" {0:X2}", c);
            }//for 
            tbTest2.Text = sb.ToString();
        }

        private void btnNoop_Click(object sender, EventArgs e)
        {
            if (btnNoop.Text == "Ready") {
                //이름만 추출하세요 첫번째와 두번째 ','사이에 있는 
                //string.indexOf(),string.SubString() 메서드이용
                //string s1 = sStr.Substring(10);//10번 인덱스 이후의 문자열

                /* int n = sStr.IndexOf(",");// ","문자열의 최초 위치
                                           //string n1 = n.ToString();
                                          // MessageBox.Show(n1);
                 int n1 = sStr.IndexOf(",", n + 1);
                 int n2 = sStr.IndexOf(",",n1+1);
                 int len = n1 - n-1;
                 string s1 = sStr.Substring(n+1,len);*/
                string ss = GetToken(sStr, ",", 3);
                MessageBox.Show(ss);


           
                
            }//if
        }

        string sPath = @".\WinApp1.ini";


        //함수의 일반화 #2 - Getini_int(string section, string key);
        //              인수 (Arg) section : InI 파일의 Section 이름
        //                         key  : key 이름
        //                         def  : default int value
        //              return : nValue : InI 파일에 추출한 파라미터 값(int)
        //함수의 일반화 #3 - GetInI_String(string section, string key);
        public int GetInIInt(string sec, string key, int def = 0) { //선택적 변수 초기화:디폴트 값을 0으로 미리 줄 수 있음
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(sec,key, $"{def}", sb, 500, sPath); 
            int nVal = int.Parse(sb.ToString());
            return nVal;
        }

        public string GetInIString(string sec, string key,string def) {
            StringBuilder sb = new StringBuilder();
             GetPrivateProfileString(sec, key, $"{def}", sb, 500, sPath);
            string sVal = sb.ToString();
            return sVal;
         }

       
        private void FormTest1_Load(object sender, EventArgs e)
        {
            

            //StringBuilder sb = new StringBuilder();

            
            cn1 = GetInIInt("Form2 Combo Set", "cn1");
            cn2 = GetInIInt("Form2 Combo Set", "cn2");
            cn3 = GetInIInt("Form2 Combo Set", "cn3");
            cn4 = GetInIInt("Form2 Combo Set", "cn4");
            cn5 = GetInIInt("Form2 Combo Set", "cn5");

            /*
            GetPrivateProfileString("Form2 Combo Set", "cn1", "0", sb, 500, sPath); cn1 = int.Parse(sb.ToString());
            GetPrivateProfileString("Form2 Combo Set", "cn2", "0", sb, 500, sPath); cn2 = int.Parse(sb.ToString());
            GetPrivateProfileString("Form2 Combo Set", "cn3", "0", sb, 500, sPath); cn3 = int.Parse(sb.ToString());
            GetPrivateProfileString("Form2 Combo Set", "cn4", "0", sb, 500, sPath); cn4 = int.Parse(sb.ToString());
            GetPrivateProfileString("Form2 Combo Set", "cn5", "0", sb, 500, sPath); cn5 = int.Parse(sb.ToString());
            */
           

            /* GetPrivateProfileString("Window Configuration", "Width", "1000", sb, 500, sPath); this.Width = int.Parse(sb.ToString());
             GetPrivateProfileString("Window Configuration", "Heigh", "700", sb, 500, sPath); this.Height = int.Parse(sb.ToString());
            */
           this.Width = GetInIInt("Window Configuration", "Width", 1000);
           this.Height = GetInIInt("Window Configuration", "Heigh", 700);

            tbTest.Text = GetInIString("tbTest", "tbTest.Text","");

        }

        private void FormTest1_FormClosed(object sender, FormClosedEventArgs e)
      {                   //string.Format("stringFormatText",arg1.arg2....)



          WritePrivateProfileString("Form2 Combo Set", "cn1", $"{cn1}", sPath);
          WritePrivateProfileString("Form2 Combo Set", "cn2", $"{cn2}", sPath);
          WritePrivateProfileString("Form2 Combo Set", "cn3", $"{cn3}", sPath);
          WritePrivateProfileString("Form2 Combo Set", "cn4", $"{cn4}", sPath);
          WritePrivateProfileString("Form2 Combo Set", "cn5", $"{cn5}", sPath);
          //WritePrivateProfileString("Form2 Combo Set", "cn1", string.Format("{0}",cn1)", "0", sPath);

          WritePrivateProfileString("Window Configuration", "Width", $"{this.Width}", sPath);
          WritePrivateProfileString("Window Configuration", "Heigh", $"{this.Height}", sPath);

          WritePrivateProfileString("tbTest", "tbTest.Text", $"{tbTest.Text}", sPath);

        }

      private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
      {
         /* 
         string com = comboBox2.Text; //콤보박스창에 표시된 문자열
          int m = int.Parse(comboBox2.Items[comboBox2.SelectedIndex].ToString());
          int com2 = int.Parse(com);
          string ss = GetToken(sStr, ",", com2);
          tbTest.Text = ss;*/

            int n = int.Parse(comboBox2.Text); //콤보박스창에 표시된 문자열
            int m = int.Parse(comboBox2.Items[comboBox2.SelectedIndex].ToString());//선택된 값을 받아오기 위해사용
            string ss = GetToken(sStr, ",", n);
            tbTest.Text = ss;



        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string s1 = GetToken(sStr,",",4);
            int n = int.Parse(s1); // comboBox 5번창에 표시된 문자열
            //tbTest.Text = string.Format("{0,10}",n);
            //tbTest.Text = string.Format("{0,10:c} {0,10:d} {0,10:e} {0,10:x} {0,10:g} {0,10:n} {0,10:p}", n); 
            tbTest.Text = string.Format("{0,10:C}",2.5);
            tbTest.Text += string.Format("\r\n{0,10:c}", -2.5);
            tbTest.Text += string.Format("\r\n{0,10:d5}", 25);
            tbTest.Text += string.Format("\r\n{0,10:e}", 25);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}//name space
