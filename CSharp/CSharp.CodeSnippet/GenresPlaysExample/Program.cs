using System;
using System.Linq;

namespace GenresPlaysExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // ["classic", "pop", "classic", "classic", "pop", "k-pop"]	[500, 600, 150, 800, 2500, 10000]	[5, 4, 1, 3, 0]
            string[] genres = new string[] { "classic", "pop", "classic", "classic", "pop", "k-pop" };
            int[] plays = new int[] { 500, 600, 150, 800, 2500, 10000 };

            var solutionClass = new SolutionClass();
            var topSongs = solutionClass.Solution(genres, plays);

            // int[] numbers = new int[] { 319, 5, 9, 341, 399, 30, 3, 34, 31, 304, 302, 10, 11, 27, 21, 100, 1000 };
            int[] numbers = new int[] { 0, 0, 0, 0 };

            CustomComparer customComparer = new CustomComparer();
            var sortedNumber = numbers.OrderByDescending(n => n, customComparer);

            var sortedTxtNumber = numbers.Select(n => n.ToString())
                                         .OrderByDescending(nTxt => nTxt.PadRight(4, nTxt.First()))
                                         .ThenByDescending(nTxt => nTxt.Length);

            Console.WriteLine("topSongs = [{0}]", string.Join(", ", topSongs));
            Console.WriteLine("numbers = [{0}]", string.Join(", ", numbers));

            Console.WriteLine("sortedNumber = [{0}]", string.Join(", ", sortedNumber));
            Console.WriteLine("Final Number = [{0}]", sortedNumber.All(n => n == 0) ? "0" : string.Join("", sortedNumber));

            Console.WriteLine("sortedTxtNumber = [{0}]", string.Join(", ", sortedTxtNumber));

            Console.ReadLine();
        }
    }
}
