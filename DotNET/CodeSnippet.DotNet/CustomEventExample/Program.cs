using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter(new Random().Next(10, 20));
            counter.ThresholdReached += counter_ThresholdReached1;
            counter.ThresholdReached += counter_ThresholdReached2;

            Console.WriteLine("press 'a' key to increase total");
            
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                counter.Add(1);
            }


            Console.ReadLine();
        }


        static void counter_ThresholdReached1(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("##### 00001 The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
        }

        static void counter_ThresholdReached2(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("##### 00002 The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
        }
    }
}
