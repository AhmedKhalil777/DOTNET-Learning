using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Add the Library
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(job_A);
            Thread thread2 = new Thread(job_B);

            thread1.Start();
            thread2.Start();

            //job_A();
            //job_B();
            Console.ReadKey();
        }

        public static void job_A()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thread A");
                Thread.Sleep(1000);
            }
        }

        public static void job_B()
        {
            for (int i = 0; i < 3; i++)
            {
                
                Console.WriteLine("Thread B");
                Thread.Sleep(10000);
            }
        }
    }
}
