using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch103.ForVsForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            // RunCase01();
            RunCase02();
            RunCase03();

            Console.ReadLine();
        }

        private static void RunCase01()
        {
            var heavyQuery = Enumerable.Range(0, 10).Where(c => {
                Task.Delay(1000).Wait();

                return true;
            });

            var start = DateTime.Now;

            for (int idx = 0; idx < heavyQuery.Count(); idx++)
            {
                Console.Write(heavyQuery.ElementAt(idx));
            }

            Console.WriteLine("Case-01 소요시간: {0}", DateTime.Now - start);
            Console.WriteLine();
        }

        private static void RunCase02()
        {
            var heavyQuery = Enumerable.Range(0, 10).Where(c => {
                Task.Delay(1000).Wait();

                return true;
            });


            var start = DateTime.Now;
            var enumerator = heavyQuery.GetEnumerator();
            for (; enumerator.MoveNext();)
            {
                Console.Write(enumerator.Current);
            }

            Console.WriteLine("Case-02 소요시간: {0}", DateTime.Now - start);
            Console.WriteLine();
        }

        private static void RunCase03()
        {
            var heavyQuery = Enumerable.Range(0, 10).Where(c => {
                Task.Delay(1000).Wait();

                return true;
            });


            var start = DateTime.Now;
            foreach (var item in heavyQuery)
            {
                Console.Write(item);
            }

            Console.WriteLine("Case-03 소요시간: {0}", DateTime.Now - start);
            Console.WriteLine();
        }
    }
}
