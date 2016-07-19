using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeToByteString
{
    public class NumberToBytesPresenter
    {
        private string[] units = { "bytes", "KB", "MB", "GB", "TB", "PB" };

        public NumberToBytesPresenter() : this(100)
        {
        }

        public NumberToBytesPresenter (int sizeNumber)
        {
            this.SizeNumber = sizeNumber;
        }

        public int SizeNumber { get; set; }

        public string GetSizeString(int precision)
        {
            if (precision < 1) precision = 1;

            var unitIndex = (int)Math.Floor(Math.Log10(SizeNumber) / Math.Log10(1024));
            string precisionFormat = string.Format("{{0:F{0}}} {{1}}", precision);

            Console.WriteLine("Math.Log10(SizeNumber) = [{0}]", Math.Log10(SizeNumber));
            Console.WriteLine("Math.Log10(1024) = [{0}]", Math.Log10(1024));
            Console.WriteLine("unitIndex = [{0}]", unitIndex);
            Console.WriteLine("precisionFormat = {0}", precisionFormat);

            var result = string.Format(precisionFormat, SizeNumber / Math.Pow(1024, unitIndex), units[unitIndex]);

            return result;
        }
    }
}
