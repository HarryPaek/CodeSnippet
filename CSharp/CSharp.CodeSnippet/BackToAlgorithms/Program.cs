using System;

namespace BackToAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Frog.NumberOfWays(3));

            Console.WriteLine("Press <ENTER> to continue....");
            Console.ReadLine();

            string testString = "Noel sees Leon.";

            Console.WriteLine("IsPalindrome(\"{0}\") = [{1}]", testString, Palindrome.IsPalindrome(testString));

            Console.ReadLine();
        }
    }
}
