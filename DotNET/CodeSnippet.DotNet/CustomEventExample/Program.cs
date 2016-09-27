using CustomEventSample.Events;
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
            IThresholdEventDelegate<ThresholdReachingEventArgs> thresholdReachingEventHandler = new ImplThresholdEventDelegate<ThresholdReachingEventArgs>();
            thresholdReachingEventHandler.EventDelegate += counter_ThresholdReaching1;
            // thresholdReachingEventHandler.EventDelegate += counter_ThresholdReaching2;

            IThresholdEventDelegate<ThresholdReachedEventArgs> thresholdReachedEventHandler = new ImplThresholdEventDelegate<ThresholdReachedEventArgs>();
            thresholdReachedEventHandler.EventDelegate += counter_ThresholdReached1;
            thresholdReachedEventHandler.EventDelegate += counter_ThresholdReached2;

            Counter counter = new Counter(new Random().Next(10, 20)) { ThresholdReachedEventHandler = thresholdReachedEventHandler, ThresholdReachingEventHandler = thresholdReachingEventHandler };

            Console.WriteLine("press 'a' key to increase total");
            
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                counter.Add(1);
            }

            Console.ReadLine();
        }


        static void counter_ThresholdReaching1(object sender, ThresholdReachingEventArgs e)
        {
            Console.WriteLine("##### 00001 The threshold of {0} was reaching at {1}.", e.Threshold, e.TimeReached);
            // e.Cancel = true;
        }

        static void counter_ThresholdReaching2(object sender, ThresholdReachingEventArgs e)
        {
            Console.WriteLine("##### 00002 The threshold of {0} was reaching at {1}.", e.Threshold, e.TimeReached);
            // e.Cancel = true;
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
