using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
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


        delegate void AddTextCallBack(string str);//함수의 포인터와 유사,함수의 주소만 참조해서 호출함 ,함수의 포인터 선언

        private void AddText(string str) {
            if (this.tbmemo.InvokeRequired)//
            {
                AddTextCallBack d = new AddTextCallBack(AddText);
                this.Invoke(d,new object[] { str});
            }
            else
            {
                tbmemo.Text += str;
            }
        }

        TcpListener _Listen;//server
        TcpClient _Sock;
        byte[] buf = new byte[20000];//버퍼와 버퍼의 크기를 잡아준다

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_Listen == null)
            {
                _Listen = new TcpListener(int.Parse(tbPort.Text)); //endpoint 나와 연결될 상대지정하는 것 
            }//if
            _Listen.Start();
            Thread ServerThread = new Thread(ServerPocess);
            ServerThread.Start();//스레드 실행
            //.............     
           // _Listen.Stop();
            
        }//click

        private void ServerPocess()//서버 스레드함수
        {
            while (true)
            {
                _Sock = _Listen.AcceptTcpClient(); //외부로부터 접속을 받아서 처리 //Session Open, Session을 통해 주고 받는 통신이 이루어짐
                //tbmemo.Text += _Sock.Client.RemoteEndPoint.ToString();스레드에서는 직접 쓰여질 수 없음
                //Cross Thread 오류:tbMemo에 직접 접근 불가 ==>invoke 필요 
                string s1 = GetToken(0,_Sock.Client.RemoteEndPoint.ToString(),":");
                AddText($"원격접속요청:{s1}\r\n");

                NetworkStream ns = _Sock.GetStream();//socket이 열렸고 그 소캣에 대해서 연결을 지어준다
               
                if (ns.DataAvailable)//데이터가 있는지 여부를 보여줌
                {
                    ns.Read(buf, 0, (int)ns.Length);//buf :Byte array
                    tbmemo.Text += buf.ToString() + "\r\n";
                }//if
            } //while
           
        }














    }
}
