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
using System.Runtime.ExceptionServices;//관리되는 예외가 처음으로 발생할 때 공용 언어 런타임에서 이벤트 처리기를 검색하기 전에 발생하는 알림 이벤트에 대한 데이터를 제공
using System.Security;
using System.Threading;//스레드 라이브러리 참조

namespace project
{
    public partial class Form1 : Form
    {
        string g_user_id = null;
        string g_accnt_no = null;

        public Form1()
        {
            InitializeComponent();
        }

        //현재 시각가져오기
        public string get_cur_tm() {
            DateTime l_cur_time;
            string l_cur_tm;

            l_cur_time = DateTime.Now;
            l_cur_tm = l_cur_time.ToString("HHmmss");

            return l_cur_tm;

        }


        /// <summary>
        /// 키움증권 종목명 가져오기 메서드 --api 연결후 사용가능
        /// </summary>
        /*public string get_jongmok_nm(sting i_jongmok_cd) {
            string l_jongmok_nm = null;
            l_jongmok_nm =axKHOpenAPI1.GetMasterCodeName(i_jongmok_cd);//종목코드의 한글명 반환
        }*/


        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Documents\ats.mdf;Integrated Security=True;Connect Timeout=30";
        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
      

        /// <summary>
        /// 메시지 로그 출력 메서드
        /// </summary>
        public void write_msg_log(string text,int is_clear) {
            DateTime l_cur_time;
            string l_cur_dt;
            string l_cur_tm;
            string l_cur_dtm;

            l_cur_dt = "";
            l_cur_tm = "";

            l_cur_time = DateTime.Now;
            l_cur_dt = l_cur_time.ToString("yyyy~") + l_cur_time.ToString("MM~") + l_cur_time.ToString("dd");
            l_cur_tm = l_cur_time.ToString("HH:mm:ss");
            l_cur_dtm = "[" + l_cur_dt + " " + l_cur_tm + "]";

            if (is_clear ==1)
            {
                if (this.textBox_msg_log.InvokeRequired)//InvokeRequired호출자가 컨트롤이 만들어진 스레드와 다른 스레드에 있기 때문에 메서드를 통해 컨트롤을 호출하는 경우 해당 호출자가 호출 메서드를 호출해야 하는지를 나타내는 값을 가져옵니다.
                    //이벤트를 다른 함수를 통해서 대체해주는 것
                {
                    textBox_msg_log.BeginInvoke(new Action(() => textBox_msg_log.Clear()));
                    //BeginInvoke: 컨트롤의 내부 핸들이 작성된 스레드에서 지정된 대리자를 비동기식으로 실행합니다.
                }
                else
                {
                    this.textBox1.Clear();
                }
            }
            else
            {
                if (this.textBox_msg_log.InvokeRequired) {
                    textBox_msg_log.BeginInvoke(new Action(() => textBox_msg_log.AppendText(l_cur_dtm + text)));
                }
                else
                {
                    this.textBox_msg_log.AppendText(l_cur_dtm+text);
                }
            }
        }


        //오류로그
        public void write_err_log(string text,int is_clear) {
            DateTime l_cur_time;
            string l_cur_dt;
            string l_cur_tm;
            string l_cur_dtm;

            l_cur_dt = "";
            l_cur_tm = "";

            l_cur_time = DateTime.Now;
            l_cur_dt = l_cur_time.ToString("yyyy~") + l_cur_time.ToString("MM~") + l_cur_time.ToString("dd");
            l_cur_tm = l_cur_time.ToString("HH:mm:ss");
            l_cur_dtm = "[" + l_cur_dt + " " + l_cur_tm + "]";

            if (is_clear == 1)
            {
                if (this.textBox_err_log.InvokeRequired)//InvokeRequired호출자가 컨트롤이 만들어진 스레드와 다른 스레드에 있기 때문에 메서드를 통해 컨트롤을 호출하는 경우 해당 호출자가 호출 메서드를 호출해야 하는지를 나타내는 값을 가져옵니다.
                {
                    textBox_err_log.BeginInvoke(new Action(() => textBox_err_log.Clear()));
                    //BeginInvoke: 컨트롤의 내부 핸들이 작성된 스레드에서 지정된 대리자를 비동기식으로 실행합니다.
                }
                else
                {
                    this.textBox_err_log.Clear();
                }
            }
            else
            {
                if (this.textBox_err_log.InvokeRequired)
                {
                    textBox_err_log.BeginInvoke(new Action(() => textBox_err_log.AppendText(l_cur_dtm + text)));
                }
                else
                {
                    this.textBox_err_log.AppendText(l_cur_dtm + text);
                }
            }
        }


        /// <summary>
        /// 지연메서드
        /// using System.Runtime.ExceptionServices;
        ///using System.Security;
        /// </summary>
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]//코드 또는 어셈블리가 보안에 중요한 작업을 수행하도록 지정합니다
        public DateTime delay(int MS) {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0,0,0,0,MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                try
                {
                    unsafe
                    {
                        System.Windows.Forms.Application.DoEvents();//현재 메시지 큐에 있는 모든 Windows 메시지를 처리합니다.
                    }
                }
                catch (AccessViolationException ex1)
                {

                    write_err_log("delay() ex1.Message :[" + ex1.Message +"]\n",0);
                }//catch
                ThisMoment = DateTime.Now;
            }//while

            return DateTime.Now; 
        }

        int g_scr_no = 0; //Open_API 요청번호
        //요청번호 부여 메서드
        private string get_scr_no() { //Open_API 화면번호 가져오기 메서드
            if (g_scr_no < 9999)
            {
                g_scr_no++;
            }
            else
            {
                g_scr_no = 1000;
            }
            return g_scr_no.ToString();
        }


        public string GetDBData(string Table, string Field, string KField, string Kvalue)
        {

            sCmd.CommandText = $"Select {Field} from {Table} where {KField}='{Kvalue}'";

            return sCmd.ExecuteScalar().ToString();//select문 처리결과 수신   

        }

        //로그인 메서드 
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* int ret = 0;
             int ret2 = 0;

             string l_accno = null;//증권계좌번호
             string l_accno_cnt = null;//소유한 증권계좌번호의 수
             string[] l_accno_arr = null;//N개의 증권계좌번호를 저장할 배열

             //ret = axKHOpenAPI1.ComConnect();
             if (ret == 0)
             {
                 tooltip.Text = "로그인중";

                 for (; ; )
                 {
                    // ret2 = axKHOpenAPI1.GetConnectState();//로그인 완료여부를 가져옴
                     if (ret2==1)//로그인이 완료되면
                     {
                         break;//반복문을 벗어남
                     }
                     else
                     {
                         delay(1000);//1초지연
                     }
                     tooltip.Text = "로그인 완료";
                     g_user_id = "";
                     //g_user_id = axKHOpenAPI1.GetLoginInfo("USER_ID").Trim();//사용자 아이드를 가져와서 클래스 변수에 저장
                     textBox1.Text = g_user_id;//클래스 변수에 저장한 아이디를 텍스트박스에 출력

                     l_accno_cnt = "";
                     // l_accno_cnt = axKHOpenAPI1.GetLoginInfo("ACCNO_CNT").Trim();//사용자의 증권계좌번호 수를 가져옴

                     l_accno_arr = new string[int.Parse(l_accno_cnt)];
                     l_accno = "";
                     // l_accno =  = axKHOpenAPI1.GetLoginInfo("ACCNO").Trim();//사용자의 증권계좌번호를 가져옴
                     l_accno_arr = l_accno.Split(';');

                     comboBox1.Items.Clear();
                     comboBox1.Items.AddRange(l_accno_arr);//증권계좌번호들을 콤보박스에 저장
                     comboBox1.SelectedIndex = 0;//첫 번째 계좌번호를 콤보박스 초기 선택으로 설정
                     g_accnt_no = comboBox1.SelectedItem.ToString().Trim();//설정된 증권계좌번호를 클래스 변수에 저장
                 }//for
             }//if*/
            try
            {

                sConn.ConnectionString = connString;
                sConn.Open();
                sCmd.Connection = sConn;

                g_user_id = textBox1.Text;              
                string s1 = GetDBData("TB_ACCNT", "USER_ID", "USER_ID", g_user_id).Trim();

                string l_accno = null;//증권계좌번호
                //string l_accno_cnt = null;//소유한 증권계좌번호의 수
                string[] l_accno_arr = null;//N개의 증권계좌번호를 저장할 배열

                if (g_user_id == s1)
                {
                    

                    //l_accno_cnt = "";
                    //l_accno_cnt = GetDBData("TB_ACCNT", "USER_ID", "USER_ID", g_user_id).Trim();//사용자의 증권계좌번호 수를 가져옴

                    //l_accno_arr = new string[int.Parse(l_accno_cnt)];
                    l_accno = "";
                    l_accno = GetDBData("TB_ACCNT", "ACCNT_NO", "USER_ID", g_user_id).Trim();//사용자의 증권계좌번호를 가져옴
                    l_accno_arr = l_accno.Split(';');
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(l_accno_arr);//증권계좌번호들을 콤보박스에 저장
                    comboBox1.SelectedIndex = 0;//첫 번째 계좌번호를 콤보박스 초기 선택으로 설정
                    g_accnt_no = comboBox1.SelectedItem.ToString().Trim();//설정된 증권계좌번호를 클래스 변수에 저장

                    tooltip.Text = "로그인 완료";
                    tooltip.BackColor = Color.Blue;
                }
                else
                {
                    tooltip.Text = "회원가입 정보가 없습니다.먼저 가입해주세요";
                    tooltip.BackColor = Color.Red;

                }


            }
            catch (Exception)
            {

                throw;
            }
            

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            g_accnt_no = comboBox1.SelectedItem.ToString().Trim();//설정된 증권계좌번호를 클래스 변수에 저장
            write_msg_log("사용할 증권계좌번호는 : ["+ g_accnt_no +"]입니다\n",0);
        }


        //로그아웃
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sConn.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            tooltip.Text = "로그아웃 완료";
            tooltip.BackColor = Color.Blue;
        }


        //거래종목 조회
        SqlDataReader reader=null;
        private void button1_Click(object sender, EventArgs e)
        {
           
            
            string l_jongmok_cd;
            string l_jongmok_nm;
            int l_priority;
            int l_buy_amt;
            int l_buy_price;
            int l_target_price;
            int l_cut_loss_price;
            string l_buy_trd_yn;
            string l_sell_trd_yn;
            int l_seq = 0;
            string[] l_arr = null;

            sCmd.CommandText = "SELECT JONGMOK_CD,JONGMOK_NM,PRIORITY,BUY_AMT,BUY_PRICE,TAEGET_PRICE,CUT_LOSS_PRICE,BUY_TRD_YN,SELL_TRD_YN FROM TB_TRD_JONGMOK WHERE USER_ID ='" + g_user_id+ "'order by PRIORITY";
            
            this.Invoke(new MethodInvoker(delegate() {
                dataGridView1.Rows.Clear();
            }));
            try
            {
                 reader = sCmd.ExecuteReader(); //reader.getstring(0)
                l_jongmok_cd = "";
                l_jongmok_nm = "";
                l_priority = 0;
                l_buy_amt = 0;
                l_buy_price = 0;
                l_target_price = 0;
                l_cut_loss_price = 0;
                l_buy_trd_yn = "";
                l_sell_trd_yn = "";
                while (reader.Read())
                {
                    //reader.Read();
                    l_seq++;
                    l_jongmok_cd = "";
                    l_jongmok_nm = "";
                    l_priority = 0;
                    l_buy_amt = 0;
                    l_buy_price = 0;
                    l_target_price = 0;
                    l_cut_loss_price = 0;
                    l_buy_trd_yn = "";
                    l_sell_trd_yn = "";
                    l_seq = 0;

                    l_jongmok_cd = reader.GetString(0).Trim();
                    l_jongmok_nm = reader.GetString(1).Trim();
                    l_priority = reader.GetInt32(2);
                    l_buy_amt = reader.GetInt32(3);
                    l_buy_price = reader.GetInt32(4);
                    l_target_price = reader.GetInt32(5);
                    l_cut_loss_price = reader.GetInt32(6);
                    l_buy_trd_yn = reader.GetString(7).Trim();
                    l_sell_trd_yn = reader.GetString(8).Trim();

                    l_arr = null;
                    l_arr = new string[] {//가져온 결과 배열에 저장
                    l_seq.ToString(),
                    l_jongmok_cd,
                    l_jongmok_nm,
                    l_priority.ToString(),
                    l_buy_amt.ToString(),
                    l_buy_price.ToString(),
                    l_target_price.ToString(),
                    l_cut_loss_price.ToString(),
                    l_buy_trd_yn,
                    l_sell_trd_yn
                    };
                    /*this.Invoke(new MethodInvoker(
                        delegate ()
                        {
                        }));*/
                    dataGridView1.Rows.Add(l_arr);//데이터그리드뷰에 추가
                }
               
                write_msg_log("테이블조회\r\n",0);
                reader.Close();

            }
            catch (Exception ex1)
            {
                write_err_log("ex.Message : [" + ex1.Message + "]\n", 0);
            }

           // reader.Close();
        }


        //삽입
        private void button3_Click(object sender, EventArgs e)
        {
            g_user_id = textBox1.Text;
            string l_jongmok_cd;
            string l_jongmok_nm;
            int l_priority;
            int l_buy_amt;
            int l_buy_price;
            int l_target_price;
            int l_cut_loss_price;
            string l_buy_trd_yn;
            string l_sell_trd_yn;

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) != true)
                {
                    continue;
                }

                if (Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
                {
                    l_jongmok_cd = Row.Cells[1].Value.ToString();
                    l_jongmok_nm = Row.Cells[2].Value.ToString();
                    l_priority = int.Parse(Row.Cells[3].Value.ToString());
                    l_buy_amt = int.Parse(Row.Cells[4].Value.ToString());
                    l_buy_price = int.Parse(Row.Cells[5].Value.ToString());
                    l_target_price = int.Parse(Row.Cells[6].Value.ToString());
                    l_cut_loss_price = int.Parse(Row.Cells[7].Value.ToString());
                    l_buy_trd_yn = Row.Cells[8].Value.ToString();
                    l_sell_trd_yn = Row.Cells[9].Value.ToString();


                    try
                    {
                        sCmd.CommandText = "insert into TB_TRD_JONGMOK values('"+ g_user_id + "', " +"'"+ l_jongmok_cd +"', " +"'" + l_jongmok_nm + "',"+l_priority+", "+ l_buy_amt + ", " + l_buy_price + ", " + l_target_price + ", " + l_cut_loss_price + ", '" + l_buy_trd_yn + "', " +"'"+l_sell_trd_yn + "', "+"'"+ g_user_id + "', GETDATE(), NULL, NULL)";
                        sCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex1)
                    {

                        write_err_log("ex.Message : [" + ex1.Message + "]\n", 0);
                    }
                    write_msg_log("테이블삽입\n", 0);
                }
            }
        }

        //수정
        private void button2_Click(object sender, EventArgs e)
        {
            string l_jongmok_cd;
            string l_jongmok_nm;
            int l_priority;
            int l_buy_amt;
            int l_buy_price;
            int l_target_price;
            int l_cut_loss_price;
            string l_buy_trd_yn;
            string l_sell_trd_yn;

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) !=true)
                {
                    continue;
                }

                if (Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
                {
                    l_jongmok_cd = Row.Cells[1].Value.ToString();
                    l_jongmok_nm = Row.Cells[2].Value.ToString();
                    l_priority = int.Parse(Row.Cells[3].Value.ToString());
                    l_buy_amt = int.Parse(Row.Cells[4].Value.ToString());
                    l_buy_price = int.Parse(Row.Cells[5].Value.ToString());
                    l_target_price = int.Parse(Row.Cells[6].Value.ToString());
                    l_cut_loss_price = int.Parse(Row.Cells[7].Value.ToString());
                    l_buy_trd_yn = Row.Cells[8].Value.ToString();
                    l_sell_trd_yn = Row.Cells[9].Value.ToString();

                    
                    try
                    {
                        sCmd.CommandText = "UPDATE TB_TRD_JONGMOK SET JONGMOK_NM='" + l_jongmok_nm + "', PRIORITY=" + l_priority + ", BUY_AMT=" + l_buy_amt + ", BUY_PRICE=" + l_buy_price + ", TAEGET_PRICE=" + l_target_price + ", CUT_LOSS_PRICE=" + l_cut_loss_price + ", BUY_TRD_YN='" + l_buy_trd_yn + "', SELL_TRD_YN='" + l_sell_trd_yn + "', UPDT_ID='" + g_user_id + "', UPDT_DTM=GETDATE() WHERE JONGMOK_CD='" + l_jongmok_cd + "' AND USER_ID='" + g_user_id + "'";
                        sCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex1)
                    {

                        write_err_log("ex.Message : [" + ex1.Message + "]\n", 0);
                    }
                    write_msg_log("테이블수정\n", 0);
                }
            }
        }


        //삭제
        private void button4_Click(object sender, EventArgs e)
        {
            string l_jongmok_cd;
           

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) != true)
                {
                    continue;
                }

                if (Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
                {
                    l_jongmok_cd = Row.Cells[1].Value.ToString();


                    try
                    {
                        sCmd.CommandText = "delete from TB_TRD_JONGMOK WHERE JONGMOK_CD='" + l_jongmok_cd + "' AND USER_ID='" + g_user_id + "'";
                        sCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex1)
                    {

                        write_err_log("ex.Message : [" + ex1.Message + "]\n", 0);
                    }
                    write_msg_log("테이블삭제\n", 0);
                }
            }
        }



        int g_is_thread = 0; //0이면 스레드 미생성, 1이면 스레드 생성 
        Thread thread1 = null;//생성된 스레드 객체를 담을 변수
        //자동매매시스템
        private void button5_Click(object sender, EventArgs e)
        {
            if (g_is_thread == 1)//스레드가 이미 생성된 상태라면
            {
                write_msg_log("이미 시작되었습니다\n",0);
                return;//이벤트메서드종료
            }
            g_is_thread = 1;//스레드생성으로 값 설정
            thread1 = new Thread(new ThreadStart(m_thread1));//스레드생성
            thread1.Start();//스레드 시작
        }


        public void m_thread1() {
            string l_cur_tm = null;
            if (g_is_thread == 0)//최초 스레드 생성
            {
                g_is_thread = 1; //중복 스레드 반복생성 방지
                write_msg_log("자동매매가 시작되었습니다\n", 0);
            }

            for (; ; )//첫번째무한루프시작
            {
                l_cur_tm = get_cur_tm();//현재시각 조회
                if (l_cur_tm.CompareTo("083001") >=0)//8시 30분 이후라면
                {

                }
                if (l_cur_tm.CompareTo("090001") >= 0)//9시 00분 이후라면
                {
                    for (; ; )
                    {
                        l_cur_tm = get_cur_tm();//현재시각 조회
                        if (l_cur_tm.CompareTo("153001") >= 0)//15시 30분 이후라면
                        {
                            break;
                        }
                        delay(200);
                    }
                }
                delay(200);
            }
        }


        //자동매매 중지
        private void button6_Click(object sender, EventArgs e)
        {

        }















        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
