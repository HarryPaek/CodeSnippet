using System;
using System.Collections.Generic;
using System.Linq;

namespace Ch109.OutOfMemory
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

            int index = 0;
            foreach (var item in list)
            {
                Console.WriteLine("list[{0}].GetSum() = [{1}]", index, item.GetSum());
                index++;
            }

            Console.ReadLine();
        }
    }

    internal class SimpleSum
    {
        public Func<long> GetSum;
        public SimpleSum(int max)
        {
            IEnumerable<int> enumAll = Enumerable.Range(0, max);
            GetSum = () => { return enumAll.Sum(); };
        }
    }
}
