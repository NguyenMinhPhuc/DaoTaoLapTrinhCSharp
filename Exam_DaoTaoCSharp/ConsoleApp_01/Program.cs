using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibrary_01;

namespace ConsoleApp_01
{
    class Program
    {
        static void HoanVi(ref int a,ref int b )
        {
            int temp;
            temp = a;
            a = b;
            b = temp;

            Console.WriteLine(string.Format("Trong: a={0}; b={1}", a, b));
        }
        static void Cong(int a,int b, out int c)
        {
            c = a + b;
        }
        static void Main(string[] args)
        {
            //Bien - Attribute
            //kieu du lieu tenBien;
            int a = 5;
            int b = 10;
            double d = 4.6;
            float f = 100000f;
            
            int c=9;
            f = c;
            c = Convert.ToInt32(f);
            bool _bool = true;
            string st = _bool.ToString();
            bool kieu = Convert.ToBoolean(st);
            
            Console.WriteLine(string.Format("Truoc: a={0}; b={1}", a, b));
            HoanVi(ref a,ref b);
            Cong(a, b,out c);
            Console.WriteLine(f.ToString());
            Console.WriteLine(string.Format("sau: a={0}; b={1}", a, b));
            
            if(a>10)
            {
                Console.WriteLine("a>10");
            }
            else
            {
                Console.WriteLine("a<=10");
            }


            if (a > 10)
            {
                Console.WriteLine("a>10");
            }
            else if(b>10)
            {
                Console.WriteLine("a<=10 and b>10");
            }
            else
            {
                Console.WriteLine("a<=10 and b<=10");
            }
            //dang 3
            if (a>10)
            {
                Console.WriteLine("a>10");
                if (c > 10)
                {
                    Console.WriteLine("a>10 and c>10");
                }
            }
            else if (b > 10)
            {
                Console.WriteLine("a<=10 and b>10");
            }
            else
            {
                Console.WriteLine("a<=10 and b<=10");
            }
            int thang = 10;
            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine(31.ToString());
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine(30.ToString());
                    break;
                case 2:
                    Console.WriteLine(28.ToString());
                    break;
                default:
                    break;
            }

            //Cau truc Lap 
            //bat dau
            // ket thuc
            // Tang
            for (int i = 0; i < 10; i++)
            {

            }
            //
            do
            {
                //

            } while (true);
            //
            while (true)
            {

            }
            //
            string ttr= "Dai hoc lac hong";
            foreach (char item in ttr.ToCharArray())
            {

            }
            Console.ReadLine();
        }
    }
}
