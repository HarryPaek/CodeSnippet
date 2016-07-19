using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeToByteString
{
    class Program
    {
        static void Main(string[] args)
        {
            var presenter = new NumberToBytesPresenter();

            presenter.SizeNumber = 1000000;
            Console.WriteLine("{0} = [{1}]", presenter.SizeNumber, presenter.GetSizeString(2));
            Console.WriteLine("===============================================================================");

            presenter.SizeNumber = 1100000;
            Console.WriteLine("{0} = [{1}]", presenter.SizeNumber, presenter.GetSizeString(2));
            Console.WriteLine("===============================================================================");

            presenter.SizeNumber = 1111100000;
            Console.WriteLine("{0} = [{1}]", presenter.SizeNumber, presenter.GetSizeString(2));
            Console.WriteLine("===============================================================================");

            Console.ReadLine();
        }
    }
}
