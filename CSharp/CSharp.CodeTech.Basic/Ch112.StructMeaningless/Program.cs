using System;

namespace Ch112.StructMeaningless
{
    struct TenMumbersStruct
    {
        public double t00, t01, t02, t03, t04, t05, t06, t07, t08, t09;
    }

    class TenMumbersClass
    {
        public double t00, t01, t02, t03, t04, t05, t06, t07, t08, t09;
    }

    class Program
    {
        private static double calcStruct(TenMumbersStruct t)
        {
            return t.t00 + t.t01 + t.t02 + t.t03 + t.t04 + t.t05 + t.t06 + t.t07 + t.t08 + t.t09;
        }

        private static double calcClass(TenMumbersClass t)
        {
            return t.t00 + t.t01 + t.t02 + t.t03 + t.t04 + t.t05 + t.t06 + t.t07 + t.t08 + t.t09;
        }

        static void Main(string[] args)
        {
            double sumStruct = 0;
            double sumClass = 0;

            var start = DateTime.Now;

            for (int index = 0; index < 100000000; index++)
            {
                sumStruct += calcStruct(new TenMumbersStruct());
            }

            Console.WriteLine("Struct Sum = [{0}]", sumStruct);
            Console.WriteLine("Struct Elapsed Time = [{0}]", DateTime.Now - start);

            start = DateTime.Now;

            for (int index = 0; index < 100000000; index++)
            {
                sumClass += calcClass(new TenMumbersClass());
            }

            Console.WriteLine("Class Sum = [{0}]", sumClass);
            Console.WriteLine("Class Elapsed Time = [{0}]", DateTime.Now - start);

            Console.ReadLine();
        }
    }
}
