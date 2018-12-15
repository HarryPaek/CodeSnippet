using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch107.AsyncLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = countDown();
            var b = countDown();

            Task.WaitAll(a, b);

            Console.ReadLine();
        }

        private static async Task countDown()
        {
            for (int idx = 9; idx >= 0; idx--)
            {
                Console.WriteLine(idx);
                await Task.Delay(1000);
            }
        }
    }
}
