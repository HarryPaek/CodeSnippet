using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValuePairListWithMaxValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> myList = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"A", 1}, {"B", 2}, {"C", 3}, {"D", 4}, {"E", 4}, {"F", 3}, {"G", 2}, {"H", 1}, //{"Z", 11}, {"Y", 0}  
            };

            var resultList = myList.Aggregate(0, (max, next) => next.Value > max ? next.Value : max, maxCount => myList.Where(e => e.Value == maxCount));

            Console.WriteLine("Done!!!");
            Console.ReadLine();
        }
    }
}
