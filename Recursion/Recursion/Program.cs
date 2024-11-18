using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(0);
            Console.WriteLine("------------");
            PrintLoop(0);
            Console.ReadLine();

        }

        static void Print(int x)
        {
            if (x == 10)
                return;

            Console.WriteLine(x);
            Print(x + 1);
        }
        static void PrintLoop(int x)
        {
            for (; x < 10; x++)
            {
                Console.WriteLine(x);
            }
        }
    }
}
