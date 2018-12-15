using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch105.Do
{
    class Program
    {
        static void Main(string[] args)
        {
            sample(9);
            sample(-1);

            Console.ReadLine();
        }

        private static void sample(int value)
        {
            do
            {
                Console.Write(value--);
            } while (value >= 0);

            Console.WriteLine();
        }
    }
}
