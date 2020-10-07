using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Delegates
{

    public delegate void CountDelegate(int limit);
    class SuperCounter
    {
        private CountDelegate algorithm;
        public SuperCounter()
        {
            algorithm= delegate (int limit){ 
            for(int i=0;i<=limit;i++)
                    Console.Write(i+" ");
                Console.WriteLine("\n");
            };
        }
        public SuperCounter(CountDelegate algo)
        {
            algorithm = algo;
        }
        public void SetAlo(CountDelegate algo)
        {
            algorithm = algo;
        }
        public void Calculate(int limit)
        {
            algorithm.Invoke(limit);
        }
    }
    class Program
    {
        public static void Fib(int limit)
        {
            int f1 = 0, f2 = 1, fn = 0;
            if (limit < 1) { return; }
           if (limit == 1) { Console.WriteLine(f1 + " " + f2); }
            if (limit > 1)
            {
                Console.Write(f1 + " " + f2+" ");
                for (int i = 0; f1+f2<=limit; i++)
                {
                    fn = f1 + f2;
                    Console.Write(fn + " ");
                    f1 = f2;
                    f2 = fn;
                }
            }
            Console.WriteLine("\n");
        }
        public static void Factorial(int limit)
        {
            int num = 1;
            if (num < 0)
                return;
            for (int i = 1; num*i <= limit; i++)
            {
                num *= i;
                Console.Write(num+" ");
            }
            Console.WriteLine("\n");
        }

        public static void Power2(int limit)
        {
            int num = 1;
            for (int i = 1; num <= limit; i++)
            {
               
                Console.Write(num + " ");
                num = (int)Math.Pow(2, i);
            }
            Console.WriteLine("\n");
        }
        public static void PrimeNumbers(int limit)
        {
            bool res;
            Console.Write(2+" ");
            for(int i = 3; i <= limit; i+=2)
            {
                res = true;
                    for(int j = 3; j * j <= i; j+=2)
                    {
                        if (i % j == 0)
                    {
                        res = false;
                        break;
                    }
                          
                    }
                    if(res)
                Console.Write(i + " ");

            }
        }
        static void Main(string[] args)
        {

            SuperCounter sc = new SuperCounter();
            Console.WriteLine("Default algorithm:");
            sc.Calculate(20);
            Console.WriteLine("\nPower of 2:");
            sc.SetAlo(Power2);
            sc.Calculate(1024);
            Console.WriteLine("\nFibonacci:");
            sc.SetAlo(Fib);
            sc.Calculate(200);
            Console.WriteLine("\nFactorial:");
            sc.SetAlo(Factorial);
            sc.Calculate(720);
            Console.WriteLine("\nPrimе numbers:");
            sc.SetAlo(PrimeNumbers);
            sc.Calculate(100);
        }
    }
}
