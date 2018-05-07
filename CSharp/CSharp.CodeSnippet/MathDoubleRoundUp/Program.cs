using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathDoubleRoundUp
{
    class Program
    {
        public static void Main()
        {
            double[] values = { 102.125, 102.135, 102.145, 103.125, 103.135, 103.145, 105, 106, 110.1, 115 };
            foreach (double value in values)
                Console.WriteLine("{0} --> {1}", value,
                                  Math.Round(value, 2, MidpointRounding.AwayFromZero));

            Console.WriteLine("\n\n십의 자리 반올림");
            Console.WriteLine("===============================================================\n");
            foreach (double value in values)
                Console.WriteLine("{0} --> {1}", value, Math.Round(value / 10, MidpointRounding.AwayFromZero) * 10);

            Console.WriteLine("\n\n십의 자리 올림");
            Console.WriteLine("===============================================================\n");
            foreach (double value in values)
                Console.WriteLine("{0} --> {1}", value, Math.Ceiling(value / 10) * 10);

            Console.ReadLine();
        }
    }
}
