using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicodeToAsciiEscape.Extensions;

namespace UnicodeToAsciiEscape
{
    class Program
    {
        static void Main(string[] args)
        {
            string unicodeString = @"백종근\AA\uabc1\u백"; // This string contains the unicode character Pi (\u03a0)";
            string escapedText = unicodeString.EncodeNonAsciiChars();
            string newUnicodeString = escapedText.DecodeNonAsciiChars();

            Console.WriteLine("Original string: {0}", unicodeString);
            Console.WriteLine("escapedText string: {0}", escapedText);
            Console.WriteLine("New Unicode string: {0}", newUnicodeString);

            /*
            // Create two different encodings.
            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(unicodeString);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);

            // Display the strings created before and after the conversion.
            Console.WriteLine("Original string: {0}", unicodeString);
            Console.WriteLine("Ascii converted string: {0}", asciiString);

            Console.ReadLine();

            asciiBytes = ascii.GetBytes(asciiString);
            unicodeBytes = Encoding.Convert(ascii, unicode, asciiBytes);

            char[] unicodeChars = new char[unicode.GetCharCount(unicodeBytes, 0, unicodeBytes.Length)];
            unicode.GetChars(unicodeBytes, 0, unicodeBytes.Length, unicodeChars, 0);

            string newUnicodeString = new string(unicodeChars);

            // Display the strings created before and after the conversion.
            Console.WriteLine("Original string: {0}", unicodeString);
            Console.WriteLine("New Unicode string: {0}", newUnicodeString);
            */

            Console.ReadLine();
        }
    }
}
