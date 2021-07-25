using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace UnicodeToAsciiEscape.Extensions
{
    public static class UnicodeStringExtension
    {
        public static string EncodeNonAsciiChars(this string unicodeText)
        {
            if (string.IsNullOrWhiteSpace(unicodeText))
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (char c in unicodeText)
            {
                sb.AppendFormat("\\u{0}", ((int)c).ToString("x4"));
            }

            return sb.ToString();
        }

        public static string DecodeNonAsciiChars(this string asciiText)
        {
            if (string.IsNullOrWhiteSpace(asciiText))
                return string.Empty;

            return Regex.Replace(asciiText, @"\\u(?<Value>[a-zA-Z0-9]{4})", m => { return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString(); });
        }
    }
}
