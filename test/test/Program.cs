using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Dog {
        protected int eyes, nose, mouse, ears;//은닉화
        virtual public void bark() {
            Console.WriteLine("멍멍");
        }
        /*public void Init() {//초기화 함수를 사용하여 외부에서 변수들을 초기화 할 수 있다--> 생성자를 만들어 해결할 수 있다
            eyes = 0;
            nose = 0;
            mouse = 0;
            ears = 0;
        }*/
        public Dog() {//타입은 클래스와 같으므로 리턴형이나 타입이 필요없다 목적이 변수 초기화 값을 외부로부터 받는 것 따라서 타입자체가 필요없다
            eyes = 0;
            nose = 0;
            mouse = 0;
            ears = 0;
        } 
    }


    public class pudle : Dog { //상속
        public pudle() {
            base.eyes = 2;
            base.nose = 1;
            base.mouse = 1;
            base.ears = 2;
        }

        public void PudleInfo() {
            Console.WriteLine("눈: {0}",base.eyes);
            Console.WriteLine("코: {0}", base.nose);
            Console.WriteLine("입: {0}", base.mouse);
            Console.WriteLine("귀: {0}", base.ears);
        }

         public override void bark()
        {
            Console.WriteLine("왈왈");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            //Dog a = new Dog();//객체 생성
            //a.Init();
            pudle pd = new pudle();
            pd.PudleInfo();
            pd.bark();
            

            
        }
    }

}
