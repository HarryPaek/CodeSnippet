using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ePlatform.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 파일명으로 허용하지 않는 문자들
        ///  - \, /, :, *, ?, ", <, >, |
        /// </summary>
        private static string NotAllowedChars = new String(Path.GetInvalidFileNameChars());

        /// <summary>
        /// 파일명으로 허용되지 않는 문자를 제거한다.
        ///  - \, /, :, *, ?, ", <, >, |
        /// </summary>
        /// <param name="text">원래 문자열</param>
        /// <returns></returns>
        public static string RemoveNotAllowedChars(this string text)
        {
            return ReplaceNotAllowedCharsWith(text, string.Empty);
        }

        /// <summary>
        /// 파일명으로 허용되지 않는 문자를 밑줄(_, Underscore)로 바꾼다.
        ///  - \, /, :, *, ?, ", <, >, |
        /// </summary>
        /// <param name="text">원래 문자열</param>
        /// <returns></returns>
        public static string ReplaceNotAllowedCharsWithUnderscore(this string text)
        {
            return ReplaceNotAllowedCharsWith(text, "_");
        }

        /// <summary>
        /// 파일명으로 허용되지 않는 문자를 지정한 문자로 바꾼다.
        ///  - \, /, :, *, ?, ", <, >, |
        /// </summary>
        /// <param name="text">원래 문자열</param>
        /// <param name="replacement">대치할 문자</param>
        /// <returns></returns>
        public static string ReplaceNotAllowedCharsWith(this string text, string replacement)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            string replacedText = Regex.Replace(text, string.Format("[{0}]", NotAllowedChars), replacement);

            return replacedText;
        }

        /// <summary>
        /// 주어진 문자열이 숫자로만 이루어 졌는지 여부를 확인
        ///  - "(+/-)123,456.789" 정도까지 허용
        /// </summary>
        /// <param name="numberText"></param>
        /// <returns></returns>
        public static bool IsDigitsOnly(this string numberText)
        {
            bool result = false;

            if (!string.IsNullOrWhiteSpace(numberText))
            {
                string tempNumberText = numberText.Trim();                                       // 공백 제거

                if (tempNumberText.StartsWith("+") || tempNumberText.StartsWith("-"))             // (+/-)로 시작하면 부호 부분 잘라냄, 부호는 1자리만 허용
                    tempNumberText = tempNumberText.Substring(1).Trim();

                if (!string.IsNullOrWhiteSpace(tempNumberText))
                    result = tempNumberText.All(c => char.IsDigit(c) || c == '.' || c == ',');   // '숫자', '.'(소수점 구분), ','(천자리 구분)만 가지고 있으면 'True'
            }

            return result;
        }

        /// <summary>
        /// 대소문자 무시한 string.Replace 확장 메서드
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceIgnoreCase(this string text, string oldValue, string newValue)
        {
            var regex = new Regex(oldValue, RegexOptions.IgnoreCase);
            string replacedText = regex.Replace(text, newValue);

            return replacedText;
        }

        /// <summary>
        /// 지정된 문자열을, 처음 발견된 위치에서만 제거함
        /// </summary>
        /// <param name="source">원래 문자열</param>
        /// <param name="remove">제거할 문자열</param>
        /// <param name="startIndex">검색을 시작할 위치</param>
        /// <returns></returns>
        public static string RemoveFirst(this string source, string remove, int startIndex = 0)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            int foundIndex = source.IndexOf(remove, startIndex, StringComparison.CurrentCultureIgnoreCase);
            string removedText = (foundIndex < 0) ? source : source.Remove(foundIndex, remove.Length);

            return removedText;
        }

        /*
        /// <summary>
        /// Get substring of specified number of characters on the right.
        /// </summary>
        */
        

        /// <summary>
        /// 주어진 문자열의 오른쪽에서 지정된 길이 만큼의 문자열을 구한다.
        /// </summary>
        /// <param name="value">문자열</param>
        /// <param name="length">문자열 길이</param>
        /// <returns></returns>
        public static string Right(this string value, int length)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            return value.Length <= length ? value : value.Substring(value.Length - length);
        }

        /// <summary>
        /// 주어진 문자열의 오른쪽에서 지정된 길이 만큼의 문자열을 구한다.
        /// - 단, 주어진 길이가 안되는 경우, 지정된 문자를 왼쪽에 추가하여 반드시 지정된 길이 문자열 리턴한다.
        /// </summary>
        /// <param name="value">문자열</param>
        /// <param name="length">문자열 길이</param>
        /// <param name="paddingChar">추가하는 문자</param>
        /// <returns></returns>
        public static string FixedLengthRight(this string value, int length, char paddingChar ='0')
        {
            return Right(value, length).PadLeft(length, paddingChar);
        }
    }
}
