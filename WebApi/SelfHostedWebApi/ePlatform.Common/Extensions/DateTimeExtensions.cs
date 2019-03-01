using System;
using System.Text;

namespace ePlatform.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static string GetFormattedText(this DateTime dateTime, string format)
        {
            try
            {
                return dateTime.ToString(format);
            }
            catch (Exception)
            {
                return dateTime.ToString("s");
            }
        }

        /// <summary>
        /// DateTime.ToString("yyyyMMddHHmmssfff")
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToLongDataTimeMillSecondString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMddHHmmssfff");
        }

        public static string ToLongDataTimeRadixString(this DateTime dateTime)
        {
            StringBuilder toReturn = new StringBuilder();

            toReturn.Append(dateTime.Year.ToRadixString().FixedLengthRight(2));
            toReturn.Append(dateTime.Month.ToRadixString().Right(1));
            toReturn.Append(dateTime.Day.ToRadixString().Right(1));
            toReturn.Append(dateTime.Hour.ToRadixString().FixedLengthRight(1));
            toReturn.Append(dateTime.Minute.ToRadixString().FixedLengthRight(2));
            toReturn.Append(dateTime.Second.ToRadixString().FixedLengthRight(2));

            return toReturn.ToString();
        }

        public static string ToLongDataTimeMillSecondRadixString(this DateTime dateTime)
        {
            StringBuilder toReturn = new StringBuilder();

            toReturn.Append(dateTime.Year.ToRadixString().FixedLengthRight(2));
            toReturn.Append(dateTime.Month.ToRadixString().Right(1));
            toReturn.Append(dateTime.Day.ToRadixString().Right(1));
            toReturn.Append(dateTime.Hour.ToRadixString().FixedLengthRight(1));
            toReturn.Append(dateTime.Minute.ToRadixString().FixedLengthRight(2));
            toReturn.Append(dateTime.Second.ToRadixString().FixedLengthRight(2));
            toReturn.Append(dateTime.Millisecond.ToRadixString().FixedLengthRight(2));

            return toReturn.ToString();
        }
    }
}

