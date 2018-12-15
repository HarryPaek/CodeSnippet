using System;
using System.Linq;

namespace Ch106.LoopWithoutLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSample01();
            RunSample02();

            Console.ReadLine();
        }

        private static void RunSample01()
        {
            int[] array = { 1, -1, 2, -2, 3 };

            Console.WriteLine(array.FirstOrDefault(c => c < 0)); // 만족하는 값이 없으면, 0가 출력됨
        }

        private static void RunSample02()
        {
            int[] array = { 1, -1, 2, -2, 3 };

            Console.WriteLine(array.Where(c => c < 0).ElementAtOrDefault(1)); // 만족하는 값이 없으면, 0가 출력됨
        }
    }
}
