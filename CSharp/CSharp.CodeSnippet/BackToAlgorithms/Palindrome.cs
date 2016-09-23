using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToAlgorithms
{
    public class Palindrome
    {
        public static bool IsPalindrome(string str)
        {
            char[] chars = str.ToCharArray();
            char[] filteredChars = chars.Where(c => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')).ToArray();
            string filtered = GetString(filteredChars);
            string reversed = GetReverseString(filteredChars);


            return filtered.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }

        private static string GetString(char[] chars)
        {
            return new string(chars);
        }

        private static string GetReverseString(char[] chars)
        {
            Array.Reverse(chars);
            return GetString(chars);
        }

        public static void Main(string[] args)
        {
            string testString = "Noel sees Leon.";

            Console.WriteLine("IsPalindrome(\"{0}\") = [{1}]", testString, IsPalindrome(testString));

            Console.ReadLine();
        }
    }
}
