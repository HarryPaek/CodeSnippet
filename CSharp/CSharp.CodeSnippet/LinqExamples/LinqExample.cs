using LinqExamples.SelectExamples;
using System;

namespace LinqExamples
{
    public class LinqExample
    {
        static void Main(string[] args)
        {
            var example = new SelectExample();

            example.SelectMany();
            example.SelectDistinct();

            Console.ReadLine();
        }
    }
}
