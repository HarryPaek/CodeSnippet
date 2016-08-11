using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var indexer = new ArrayIndexerTester();
            
            indexer[0, 0] = 10;
            indexer[0, 1] = 20;
            indexer[0, 2] = 30;
            indexer[0, 3] = 40;
            indexer[0, 4] = 50;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("indexer[0, {0}] = [{1}]", i, indexer[0, i]);
            }

            Console.ReadLine();
        }
    }
}
