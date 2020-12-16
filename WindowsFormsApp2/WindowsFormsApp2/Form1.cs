using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string key, string def, StringBuilder sb, int size, string path);

        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string Section, string key, string val, string path);

        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();

        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\source\repos\MyTable.mdf;Integrated Security=True;Connect Timeout=30";
        //string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\temp;Integrated Security=True;Connect Timeout=30";
        public Form1()//생성자 호출시 처리
        {
            InitializeComponent();
        }

        public string GetToken(int n, string str, string sep = ",")  //string str, string sep = ",", int n--> error
        {
            int i; //local index
            int n1 = 0, n2, n3; // temp int var 
            string ss;

            for (i = 0; i < n; i++)
            {
                n1 = str.IndexOf(sep, n1) + 1;//i째 구분자

                if (n1 == 0) return "";
            }//for
            n2 = str.IndexOf(sep, n1);//n+1번째 구분자
                                      //if (n2 <= n1) return "";
            if (n2 == -1) n2 = str.Length;
            n3 = n2 - n1; //문자열 길이 계산 
            ss = str.Substring(n1, n3);
            return ss;

        }//GetToken


        string sPath = @".\WinApp1.ini";
        public int GetInIInt(string sec, string key, int def = 0)
        { //선택적 변수 초기화:디폴트 값을 0으로 미리 줄 수 있음
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(sec, key, $"{def}", sb, 500, sPath);
            int nVal = int.Parse(sb.ToString());
            return nVal;
        }

        public string GetInIString(string sec, string key, string def)
        {
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(sec, key, $"{def}", sb, 500, sPath);
            string sVal = sb.ToString();
            return sVal;
        }

        private void btnTest11_Click(object sender, EventArgs e)
        {//문자열 변화 테스트
            /* if (checkBox1.Checked == true) {//true 생략도 가능함
                 label1.Text = tbTest_1.Text.ToLower();
             }*/

            if (rbTest11.Checked == true)
            {//true 생략도 가능함
                label1.Text = tbTest_11.Text.ToLower();
            }

            if (rbTest22.Checked == true)
            {//true 생략도 가능함
                label1.Text = tbTest_11.Text.ToUpper();
            }
        }


        private void btnTest12_Click(object sender, EventArgs e)
        {//텍스트 창에 입력한 문자열을 콤보박스에 추가
            string str = tbTest_12.Text;
            int nVal = int.Parse(str);

            //cbTest_11.Text --> default 이름값을 정해주는 것이다
            cbTest_11.Items.Add(nVal);
        }


        private void cbTest_11_SelectedIndexChanged(object sender, EventArgs e)
        {//콤보박스에 입력된 object 추출 및 변환 테스트
            //string as1 = cbTest_11.Text;
            int nSel = cbTest_11.SelectedIndex;
            object oVal = cbTest_11.Items[nSel];
            int nVal = (int)oVal;//캐스팅해준다

            tbTest_13.Text = string.Format("{0} selected",nVal);
        }



        int cn1, cn2, cn3, cn4, cn5; //form2의 콤보박스의 선택값 보관용 변수

        private void Form1_Load(object sender, EventArgs e)
        {
           
            cn1 = GetInIInt("Form2 ComboBox Set", "cn1");
            cn2 = GetInIInt("Form2 ComboBox Set", "cn2");
            cn3 = GetInIInt("Form2 ComboBox Set", "cn3");
            cn4 = GetInIInt("Form2 ComboBox Set", "cn4");
            cn5 = GetInIInt("Form2 ComboBox Set", "cn5");
            tabControl1.SelectedIndex = GetInIInt("WindowCong","tapPage");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(DbStatus == 1) { sConn.Close(); }
            WritePrivateProfileString("Form2 ComboBox Set", "cn1", $"{cn1}", sPath);
            WritePrivateProfileString("Form2 ComboBox Set", "cn2", $"{cn2}", sPath);
            WritePrivateProfileString("Form2 ComboBox Set", "cn3", $"{cn3}", sPath);
            WritePrivateProfileString("Form2 ComboBox Set", "cn4", $"{cn4}", sPath);
            WritePrivateProfileString("Form2 ComboBox Set", "cn5", $"{cn5}", sPath);
            WritePrivateProfileString("WindowCong", "tapPage",$"{tabControl1.SelectedIndex}",sPath);
        }

        private void btnForm2Test_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();

            dlg.comboBox1.SelectedIndex = cn1;
            dlg.comboBox2.SelectedIndex = cn2;
            dlg.comboBox3.SelectedIndex = cn3;
            dlg.comboBox4.SelectedIndex = cn4;
            dlg.comboBox5.SelectedIndex = cn5;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbTest_21.Text = dlg.sRet;
                cn1 = dlg.comboBox1.SelectedIndex;
                cn2 = dlg.comboBox2.SelectedIndex;
                cn3 = dlg.comboBox3.SelectedIndex;
                cn4 = dlg.comboBox4.SelectedIndex;
                cn5 = dlg.comboBox5.SelectedIndex;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {//tbTest21, tbTest22 영역 재설정
            int w = this.Size.Width;
            int h = this.Size.Height;

            int sx1 = w / 2 - 30;
             if (sx1 > 50) {
                 //tbTest_21.Size= size(x,y);
                 tbTest_21.Width = sx1;// tbTest21의 가로 크기 변경
                 tbTest_21.Location = new Point(10, tbTest_22.Location.Y);
                 tbTest_22.Location = new Point(sx1 + 20, tbTest_22.Location.Y);   //new System.Drawing.Point(sx1+20,w-10);
                 tbTest_22.Width = sx1;
             }
        }


           
        private void btnFormTest_Click_1(object sender, EventArgs e)
        {
           
                    if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                string fPath = openFileDialog1.FileName; //full path

                FileStream fs = new FileStream(fPath,FileMode.Open);//기존에 있는 파일 불러오기
                int fSize = (int)fs.Length;
                fs.Close();

                char[] buf = new char[fSize];//파일 사이즈만큼 사이즈를 잡는다
                StreamReader sr = new StreamReader(fPath);
                //sr.Read(buf,0,fSize);
                sr.ReadLine(); //1Line Read : if(EOF) null
                tbTest_21.Text = new string(buf);
                sr.Close();
            };
        }


        //함수의 일반화 #4
        //함수명 :MemoOut(string str)
        //인수 :string str :출력할 문자열 
        //리턴값 : 없음(void)
        //기능:원도우 컴포넌트 중 지정된 텍스트 박스로 출력문자열을 누적 출력
        //추가기능 : 출력 텍스트박스 설정기능 : 초기화 기능
        System.Windows.Forms.TextBox tbOut = null;
        public void MemoOut(string str) {
            if (tbOut==null) {
                rbTest2_Click(null,null);
                //tbOut = tbTest_22;   
                tbOut.Text = str;
                
            }
            tbOut.Text = str;
        }//if

        private void btntemp_Click(object sender, EventArgs e)
        {
            /*
            int[] nArr = new int[5];
            nArr[0] = 1;
            nArr[1] = 2;
            nArr[2] = 3;
            nArr[3] = 4;

            int[] bArr = { 10, 20, 30 };

            int n1 = 0;
            foreach (int n in nArr){
                string str = $"nArr[{n1}] = {n}\r\n";
                tbTest_22.Text += str;
            }

            for (int i = 0; i < 3; i++) {
                string str = $"bArr[{i}] = {bArr[i]}\r\n";
                tbTest_22.Text += str;
            }
            */

            //string[] name = {"c#","DB","HTML" };
            /*int[,] stu_score = new int[3, 3];
            stu_score[0, 0] = 1;
            stu_score[0, 1] = 10;
            stu_score[0, 2] = 100;
            stu_score[0, 3] = 10;
            stu_score[1, 0] = 2;
            stu_score[1, 1] = 10;
            stu_score[1, 2] = 100;
            stu_score[1, 3] = 10;
            stu_score[2, 0] = 3;
            stu_score[2, 1] = 10;
            stu_score[2, 2] = 100;
            stu_score[2, 3] = 10;


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string str = $"stu_score[{i,j}] = {stu_score[i, j]}\r\n";
                    tbTest_22.Text += str;
                }
            }*/

            /*  string[] Name = { "병준","택형","정의"};//학생이름
              int nSubj = 3;
              int[] subj1 = { 90, 80, 70 };//과목별 점수
              int[] subj2 = { 60, 50, 90 };
              int[] subj3 = { 90, 30, 100 };
              int[] subj4 = { 75, 85, 90 };
              int[] total = new int[3];
              double[] avg = new double[3];

              int m = Name.Length; //배열요소의 갯수
              for (int i=0;i<m;i++) {
                  total[i] = subj1[i] + subj2[i] + subj3[i];
                  avg[i] = total[i] / nSubj;//내부적으로 형변환이 일어남
                  avg[i] = (double)total[i] / nSubj; //avg:실수,  total[i], nSubj 정수
                                              //정수와 정수의 연산의 계산관정에서 연산과정에 형변환(캐스팅) 필요
              }

              //이름    c#      db      html    total   avg 
              //==================================
              //병준    90       80      70      245    81
              //택형    60       50      90 
              //정의    90       30      100

              tbTest_22.Text += "      이름     c#     db      html      total    avg \r\n";
              tbTest_22.Text += "==========================================\r\n";
              for (int i = 0; i < m; i++)
              {
                  string str = $"{Name[i],8} {subj1[i],7} {subj2[i],7} {subj3[i],7} {total[i],8} {avg[i],10:F2}\r\n";
                  tbTest_22.Text += str;
              }

              */


            //c언어의 2차원배열 int arr[10][4]
            string[] Name = { "병준", "택형", "정의" };//학생이름
            string[] subName = { "C#","DB","C++","IOT","Web"};
            int[,] subj = { { 90, 80, 70 }, //첫째 과목 점수
                            { 60, 50, 90 }, //둘째 과목 점수
                            { 90, 30, 100 },
                            { 75, 85, 90 },
                            { 75, 85, 90 } //배열 요소위 갯수(사람수):3
                            };


            int nSubj = subj.GetLength(0);  // 첫번째 context 배열블럭의 갯수 : 5
                                            //string [5,3] 0은 앞자리 5, 1은 뒷자리 3을 의미한다  
                                            //인데스순서로 간다
            int nCnt = subj.Length;   // 15 : Total 요소 갯수
            int m = Name.Length; //배열요소의 갯수(사람수) 3

            int[] total = new int[m];//c언어에서는 동적 할당이 가능함 
            double[] avg = new double[m];
            int i,j,k; //0으로 초기화됨

            for (i = 0; i < m; i++)  //인원수 3
            {
                for (j=0, total[i]=0;j<nSubj;j++) { //과목수 (subject) 5
                    total[i] += subj[j,i]; //과목별 5자리수, 우정렬
                }

                avg[i] = (double) total[i] / nSubj; // avg : 실수,  total/nSub 정수
                                                    // 정수와 정수의 연산은 계산과정에서 정수
                                                    // 연산과정에 형변환 (캐스팅:cast)필요
            }

            string str="   이름   ";//누적되게 적용하려면 초기값을 알아야 덧붙일 수 있어서 초기화를 해주어야 한다
                                    //총 10자리
            for (j = 0; j < nSubj; j++){
                str += $"{subName[j],5}";
               
     
            }
            str += $"총점     평균\r\n";
            MemoOut(str);

            for (i = 0; i < m; i++){
               /* tbTest_21.Width = sx1;   // tbTest21 의 가로 크기 변경
                tbTest_22.Location = new Point(sx1 + 20, tbTest_21.Location.Y);
                tbTest_22.Width = sx1;   // tbTest22 의 가로 크기 변경*/
                str += $"{Name[i],6}    ";
                for (j = 0; j < nSubj; j++)
                {
                    str += $"{subj[j, i],5}";
                }
                str += $"{total[i],7}{avg[i],7:F2}\r\n";
                // tbTest_22.Text += str; 초기화가 안되어서 중복해서 나온다
                //tbTest_22.Text = str;
               MemoOut(str);
            }
            
        }//


        private void rbTest2_Click(object sender, EventArgs e)
        {
            if (rbTest1.Checked) tbOut = tbTest_21; 
            else tbOut = tbTest_22;
        }

        private void mnuTbSet21_Click(object sender, EventArgs e)
        {
            if (!mnuTbSet21.Checked)
            {
                tbOut = tbTest_21;
                mnuTbSet21.Checked = true;
                mnuTbSet22.Checked = false;
                rbTest1.Checked = true;
                rbTest2.Checked = false;
            }
           
        }

        private void mnuTbSet22_Click(object sender, EventArgs e)
        {
            if (!mnuTbSet22.Checked)
            {
                tbOut = tbTest_22;
                mnuTbSet21.Checked = false;
                mnuTbSet22.Checked = true;
                rbTest1.Checked = false;
                rbTest2.Checked = true;
            }
        }


        private void mnuSelect2(object sender, EventArgs e)
        {
            tbOut = tbTest_22;
            rbTest2.Checked = true;
        }


        private void mnuSelect1(object sender, EventArgs e)
        {
            tbOut = tbTest_21;
            rbTest1.Checked = true;
        }

        //Command 체계:
        //"컬럼 명칭" : 신규컬럼 생성
        //"1,2, 'field_value'" :해당 cell에 field_value 입력 - (1,2)

        private void btnGridCmd_Click(object sender, EventArgs e)
        {//tbGridCmd 에 입력된 text로 column생성
            string str = tbGridCmd.Text;
            try
            {
                if (str != "")
                {//입력 문자열이 공백이 아닌 경우
                    if (str.IndexOf(",") == -1)//,가 없으면 컬럼 생성
                    {
                        dataGridView1.Columns.Add(str, str);
                        tbGridCmd.Text = "";
                    }
                    else     //쿼리문이 select인 경우
                    { //해당 cell이 지정된 값으로 변환
                      //sample data: [1,2, value_12]
                        int col = int.Parse(GetToken(0, str)); //col = 1
                        int row = int.Parse(GetToken(1, str));//row = 2
                        dataGridView1.Rows[row].Cells[col].Value = GetToken(2, str);
                    }
                }
            }
            catch (Exception e1) { 
                
            }
            
        }

        int DbStatus = 0;//DB connection status
        //함수명 GetDBTableNames
        //인수 : 없음
        //return : 없음
        //기능 : 현재 Open 되어있는 DB의 table 명을 cbTable콤보박스에 넣는다.
        public void GetDBTableNames() {
            cbTable.Items.Clear();
            DataTable dt = sConn.GetSchema("Tables");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sTablename = (string)dt.Rows[i].ItemArray[2];
                cbTable.Items.Add(sTablename);
            }
        }

        private void mnDBOpen_Click(object sender, EventArgs e)
        {
            try
            {
                sConn.ConnectionString = connString;
                sConn.Open();
                sCmd.Connection = sConn;
                GetDBTableNames();

                statusLabel1.BackColor = Color.Green;
                statusLabel1.Text = "DB opend success";
                DbStatus = 1; //db가 정상적으로 Open
            }
            catch (Exception e1)
            {
                statusLabel1.Text = "DB opend failed!";
                statusLabel1.BackColor = Color.Red;
            }

        }


        private void mnuAddRow_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        public int RunSql(string sSql)
        {
            try
            {
                int i, j, k;
                sCmd.CommandText = sSql;
                string s1 = GetToken(0, sSql, " ").ToUpper(); //"select fcode,fname from facility"                
                if (s1 != "SELECT")
                {
                    sCmd.ExecuteNonQuery();//return값이 없는 쿼리문 ex)insert,delete,update 
                }
                else
                {
                    SqlDataReader sr = sCmd.ExecuteReader();//select문 처리결과 수신 //sCmd.ExecuteReader();//select                                                            

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();

                    for (i = 0; i < sr.FieldCount; i++)
                    {
                        dataGridView1.Columns.Add(sr.GetName(i), sr.GetName(i));//조회할 칼럼출력
                    }

                    //행의 수 출력 
                    for (i = 0; sr.Read(); i++) //처리할 데이터가 있으면 1라인씩 처리\// sr.Read();
                                                //조회 결과를 1라인씩 처리/  읽을 것이 있을 때만 true, 없을 때는 false로 처리된다
                    {
                        if (dataGridView1.RowCount < i + 2) dataGridView1.Rows.Add();//제목필드값이 이미 만들어 짐으로 1+
                        for (j = 0; j < sr.FieldCount; j++)//grid에서의 x값
                        {
                            object o2 = sr.GetValue(j);
                            string buf = $"{o2}";
                            dataGridView1.Rows[i].Cells[j].Value = buf;
                            // dataGridView1.Rows[i].Cells[j].Value = $"{sr.GetValue(j)}";
                        }//for
                    }//for
                    sr.Close();
                }
                statusLabel2.BackColor = Color.Blue;
                statusLabel2.Text = "Success";
                
            }
            catch (Exception ex1)
            {
                statusLabel2.BackColor = Color.Red;
                statusLabel2.Text = "command fail";
                statusLabel3.Text = ex1.Message;
            }
            return 0;
        }
        /*  private void btnExecSql_Click(object sender, EventArgs e)
          {
              int i, j, k;
              try
              {
                  string sSql = tbSql.Text;
                  sCmd.CommandText = sSql;

                  string s1 = GetToken(0, sSql, " ").ToUpper(); //"select fcode,fname from facility"                
                  if (s1 != "SELECT")
                  {
                      sCmd.ExecuteNonQuery();//return값이 없는 쿼리문 ex)insert,delete,update 

                  }
                  else
                  {
                      SqlDataReader sr = sCmd.ExecuteReader();//select문 처리결과 수신 //sCmd.ExecuteReader();//select
                                                              // sr.Read();//조회 결과를 1라인씩 처리  읽을 것이 있을 때만 true, 없을 때는 false로 처리된다

                      dataGridView1.Columns.Clear();
                      dataGridView1.Rows.Clear();

                      for (i = 0; i < sr.FieldCount;i++)
                      {
                          dataGridView1.Columns.Add(sr.GetName(i), sr.GetName(i));
                      }

                      //행의 수 출력 
                      for (i = 0;sr.Read(); i++) //처리할 데이터가 있으면 1라인씩 처리
                      {
                          if (dataGridView1.RowCount < i+2) dataGridView1.Rows.Add();
                          for (j = 0; j< sr.FieldCount; j++)//grid에서의 x값
                          {
                             object o2 = sr.GetValue(j);
                             string buf = $"{o2}";
                             dataGridView1.Rows[i].Cells[j].Value = buf;
                             // dataGridView1.Rows[i].Cells[j].Value = $"{sr.GetValue(j)}";
                          }//for
                      }//for
                      sr.Close();
                  }
                  statusLabel2.BackColor = Color.Blue;
                  statusLabel2.Text = "Success";
              }
              catch (Exception ex1)
              {
                  statusLabel2.BackColor = Color.Red;
                  statusLabel2.Text = "command fail";
              }

          }*/


        /// <summary>
        /// RunDBData(string fieldname,string Table_name)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string RunDBData(string keyname, string Table_name) {

            string sql = $"Select svalue from {Table_name} where skey='{keyname}'";
            sCmd.CommandText = sql;

            string sRet = sCmd.ExecuteScalar().ToString();//select문 처리결과 수신                                                           
            return sRet;
    }


        private void dbFileSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.ValidateNames = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fPath = openFileDialog1.FileName; //full path
                //string fPath = FileDialog1.FileName; // full path
                string s1 = GetToken(0,connString,";");//connString의 첫번째 필드.
                // @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\source\repos\MyTable.mdf;Integrated Security=True;Connect Timeout=30";
                string s2 = $"AttachDbFilename={fPath}";
                string s3 = GetToken(2, connString, ";");//connString의 세번째 필드.
                string s4 = GetToken(3, connString, ";");//connString의 네번째 필드.

              connString = s1 + ";"+ s2 + ";" + s3 + ";" + s4; //구분자 직접 삽입
                                                               //connString = $"{s1};{s2};{s3};{s4}";//보관문자열사용
                string s5 = openFileDialog1.SafeFileName;
                tbDatabase.Text = s5;
            }
        }

        /// <summary>
        /// 함수일반화 #5
        /// 함수명 : int RunSql(string sql)
        /// 인수 : string sql: 실행할 SQL문
        /// 리턴 : -1 오류, 1 or 0 정상종료 
        /// 기능 : SQL 문을 sCmd 오브젝트를 이용하여 수행하고 결과값이 있을 경우 (Select) 그리드에 표현해주고 
        ///        하단의 statusBar에 수행결과를 표시
        /// </summary>
        /// 
        ///         
        

        private void MnucellUpdate_Click(object sender, EventArgs e)
        {
            //int x = dataGridView1.SelectedCells[0].ColumnIndex;
            //int y = dataGridView1.SelectedCells[0].RowIndex;
            int x = dataGridView1.ColumnCount;
            int y = dataGridView1.RowCount;

            int i, j, k;

            for (i = 0; i < y; i++) //Row index
            {
                for (j = 0; j < x; j++)//Column index
                {
                    if (dataGridView1.Rows[i].Cells[j].ToolTipText == ".")
                    {
                        string s1 = dataGridView1.Columns[j].HeaderText;//field명 해당하는 값의 제일 위의 데이터
                        string s2 = (string)dataGridView1.Rows[i].Cells[j].Value.ToString(); //수정된 데이터
                        //string s2 =dataGridView1.SelectedCells[0].Value.ToString();
                        string s3 = dataGridView1.Rows[i].Cells[0].Value.ToString();//id 번호
                        string s4 = $"update {cbTable.Text} set {s1}='{s2}' where id ={s3} ";
                        RunSql(s4);

                        dataGridView1.Rows[i].Cells[j].ToolTipText = "";
                    }
                }
            }
            //sCmd.CommandText = s4;
            //sCmd.ExecuteNonQuery();
        }


        private void btnExecSql_Click(object sender, EventArgs e)
        {
            string sql = tbSql.SelectedText;
            if (sql != "") RunSql(sql);      
           else RunSql(tbSql.Text);
           
            tbSql.Focus();
        }


        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {//kbd(키보드)입력이 발생했을 때
            int x = dataGridView1.SelectedCells[0].ColumnIndex;
            int y = dataGridView1.SelectedCells[0].RowIndex;

            //만일 편집중인 셀이 신규 생성된 row이면(.) insert준비(..)
            if (dataGridView1.Rows[y].HeaderCell.Value.ToString() ==".")
            {
                dataGridView1.Rows[y].HeaderCell.Value = "..";
                dataGridView1.SelectedCells[0].ToolTipText = ".";//value 셀에 표시되는 데이터 
                                                                 //tag는 달아주는 보이지않는 데이터
            }


        }



        private void mnDBOclose_Click(object sender, EventArgs e)
        {
            if (DbStatus == 1)
            {
                sConn.Close();
                tbDatabase.Text = "";
                cbTable.Items.Clear();

                statusLabel1.BackColor = Color.Blue;
                statusLabel1.Text = "DB closed success";
            }
        }



        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string cbt = cbTable.Text;
           string ssSql = $"select * from  {cbTable.Text}";
            RunSql(ssSql);

        }


        private void mnuImportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ValidateNames = false;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fPath = openFileDialog1.FileName; //full path
                    StreamReader sr = new StreamReader(fPath);
                    //sr.Read(buf) : buf size 만큼의 데이터를 한번에 READ
                    string str;
                    int i, j, k;

                    //미리 비워주기
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();

                    int nCol = 0;
                    str = sr.ReadLine();////Head Line: dataGrid에 헤더컬럼 추가, 한줄을 먼저 읽고 
                    for (i = 0; ; i++)
                    {
                        string c1 = GetToken(i, str);//구분자로 해서 하나씩가져온다
                        if (c1 == "")
                        {
                            nCol = i;
                            break;
                        }//if
                        dataGridView1.Columns.Add(c1, c1);
                    }//for

                    for (i = 0; ; i++)
                    {
                        str = sr.ReadLine();
                        if (str == null) break;
                        dataGridView1.Rows.Add();
                        for (j = 0; j < nCol; j++)
                        {
                            string c1 = GetToken(j, str);//구분자로 해서 하나씩가져온다
                            dataGridView1.Rows[i].Cells[j].Value = c1;
                        }//inner for
                    }//out for
                    statusLabel2.BackColor = Color.Blue;
                    statusLabel2.Text = "Success";
                    sr.Close();
                }//if
            }//try
            catch (Exception ex1)
            {               
            }
        }



        /// <summary>
        /// 함수명 :InsertRow(int n,string[],string TABLE_NAME)
        /// 인수   : n - Insert할 Row의 Index
        /// 리턴값 :없음
        /// 기능   :지정된 Row의 모든 셀을 Table에 Inset
        /// </summary>
        public void InsertRow(int n) {
            int i, j, k;
            string sName = cbTable.Text;
            string sInsert = $"INSERT into {sName} values";
            int nCol = dataGridView1.Columns.Count;           
            string c1 = "(";
                    for (j = 0; j < nCol; j++)
                    {
                        string c2 = "";
                //string c2 = dataGridView1.Rows[n].Cells[j].Value.ToString();
                        if (dataGridView1.Rows[n].Cells[j].Value != null)
                        {
                            c2 = dataGridView1.Rows[n].Cells[j].Value.ToString();
                            c1 += $"'{c2}'";
                            if (j < nCol - 1) c1 += ",";
                        }       
                }//for
                        c1 += ")";
                        sInsert += c1;
                        RunSql(sInsert);
                         
               
        }



        //0.db파일(.mdf)은 현재 open되어 잇는 db사용
        //1.입력창을 열어서 신규 Table 이름 입력 frmGetTableName
        private void mnuDBSave_Click(object sender, EventArgs e)
        {
            frmGetTableName dlg = new frmGetTableName();
            dlg.ShowDialog();
           string sName = dlg.tbTableName.Text;

            //2.현재 grid의 헤더 컬럼을 필드 이름으로 create하는 table을 creation
            //create table [테이블명] ()
            //[필드명:컬럼명] [필드속성:nchar], .....)
            //==> SQL 실행
            int i, j;
            int nCol = dataGridView1.Columns.Count;
            int nRow = dataGridView1.Rows.Count;
            string sCreate = $"CREATE TABLE {sName}(";
            for (i = 0; i < nCol; i++)
            {
                string c1 = dataGridView1.Columns[i].HeaderText;
                sCreate += $"{c1} nchar(20)";
                if (i < nCol-1 )
                {
                    sCreate += ",";
                }//if
            }//for
            sCreate += ")";
            RunSql(sCreate);
            //3.현재 grid의 각 cell의 data를 db에 insert
            //Insert into [테이블명] values
            // (data1,.......,datan),
            //      .........       <------------------','주의
            //   ===========>SQL 실행
             string sInsert = $"insert into {sName} values";
             for (i = 0; i < nRow-1; i++)              
             {//('col1', 'col2','col3','coln')
                /*  string c1 = "(";
                 for (j = 0; j < nCol; j++)
                 {
                     string c2 = dataGridView1.Rows[i].Cells[j].Value.ToString();
                     c1 += $"'{c2}'";
                     if (j < nCol - 1) c1 += ","; 
                 }
                 c1 += ")";
                 sInsert += c1;
                 if (i < nRow -2) sInsert += ",";*/
                InsertRow(i);
            }
            //StreamReader sr = new StreamReader(fPath);
           
           // RunSql(sInsert);
            GetDBTableNames();
            //cbTable.Items.Add();              
        }

        //1.table 삭제  2.popup menu에 insert delete 메뉴 추가 구현
        private void mnuDelTable_Click(object sender, EventArgs e)
        {//테이블 삭제 메뉴
            string sTbl = cbTable.Text;
            if(sTbl != "") { 
            RunSql($"drop table {sTbl}");
            statusLabel2.Text = $"table {sTbl} dropped";

            cbTable.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            GetDBTableNames();
             return;
            }
            statusLabel2.Text = "table 삭제실패";
        }


        private void mnuDelLine_Click(object sender, EventArgs e)
        {//grid 창에 있는 table의 해당 레코드 삭제
         //현재 grid에 있는 데이터가 첫번째컴럼에 id필드를 포함한 경우에만 동작
            string sHdr = dataGridView1.Columns[0].HeaderText.ToLower();
            if (sHdr == "id")
            {
               
                int x = dataGridView1.SelectedCells[0].ColumnIndex;
                int y = dataGridView1.SelectedCells[0].RowIndex;
                string sId = dataGridView1.Rows[y].Cells[0].Value.ToString();
                string sTbl = cbTable.Text;

                RunSql($"delete {sTbl} where id={sId}");
                statusLabel2.Text = "레이블 삭제성공";
                cbTable_SelectedIndexChanged(sender,e);
                return;//else문이 없을때 끝내주기 위해 리턴을 사용한다
            }
            statusLabel2.Text = "레이블 삭제실패";
        }



        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {//datagrid의 row가 새로 생성되었을 때
            int nRow = e.RowIndex;//새로 생성된 rowIndex수
            dataGridView1.Rows[nRow].HeaderCell.Value = ".";//신규 Row flag
        }



        private void mnuDBInsert(object sender, EventArgs e)
        {//INSERT into [table] values()
            int i, j, k;
            string sTbl = cbTable.Text;
           
            int nRow = dataGridView1.Rows.Count;
            int y = dataGridView1.SelectedCells[0].RowIndex;

           
                for (i = 0; i < nRow - 1; i++)
                {//('col1', 'col2','col3','coln')
                    if (dataGridView1.Rows[i].HeaderCell.Value.ToString() == "..")
                    {
                    InsertRow(i);
                    dataGridView1.Rows[i].HeaderCell.Value = "";
                    }//if
                 }//for                
               // RunSql(sqlInsert);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = RunDBData(textBox1.Text,"MyConfig");
            tbSql.Text += $" Myconfig test [{textBox1.Text}] : '{str}'\r\n";
        }
































        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void tbTest_22_Click(object sender, EventArgs e)
        {
           
        }


        private void tbTest_21_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        

        private void chkViewHexa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void StatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void database_Click(object sender, EventArgs e)
        {

        }

       

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
