using System;
using System.Collections.Generic;
using System.Linq;

namespace Ch108.OutOfMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<SimpleSum>();

            for (int idx = 0; idx < 100000; idx++)
            {
                list.Add(new SimpleSum(10000));
            }

            Console.WriteLine("Done!!!");
            Console.ReadLine();
        }
    }

    internal class SimpleSum
    {
        private int[] array;
        private int sum;

        private void Calc()
        {
            sum = array.Sum();
        }

        public SimpleSum(int max)
        {
            array = Enumerable.Range(0, max).ToArray();
            Calc();
            array = null;
        }
    }
}
