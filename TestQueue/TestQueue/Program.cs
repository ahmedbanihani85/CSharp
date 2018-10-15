using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> Q = new Queue<int>();

            Random rnd = new Random();

            for (int i=0;i<100;i++)
            {
                Q.Enqueu(rnd.Next(1, 1000));
            }

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(Q.Dequeu().ToString());
            }

        }


    }
}
