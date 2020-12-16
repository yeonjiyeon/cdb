using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overloading
{
    public class Zerg {
        public void Overload(int zergging)
        {
            Console.WriteLine("저글링 {0} 마리", zergging);
        }

        public void Overload(int zergging, int hidra)
        {
            Console.WriteLine("저글링 {0} 마리 + 히드라 {1} 마리", zergging, hidra);
        }

        public void Overload(int zergging, int hidra, int lurker)
        {
            Console.WriteLine("저글링 {0} 마리 + 히드라 {1} 마리 + 월커 {2} 마리", zergging, hidra, lurker);
        }
        public void Overload(char zerggling)
        {
            Console.WriteLine("저글링 {0} 등급", zerggling);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Zerg zerg = new Zerg();
            zerg.Overload(10);
            zerg.Overload(10,20);
            zerg.Overload(10,20,30);
            zerg.Overload('A');
        }
    }
}
