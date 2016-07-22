using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapTwoInterfaceEvents.Impl;
using WrapTwoInterfaceEvents.SubscriberExamples;

namespace WrapTwoInterfaceEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Shape();
            SubscriberOne subOne = new SubscriberOne(shape);
            SubscriberTwo subTwo = new SubscriberTwo(shape);
            shape.Draw();

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
