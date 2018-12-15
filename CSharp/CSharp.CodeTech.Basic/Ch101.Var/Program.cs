using System;
using System.Collections.Generic;
using System.IO;

namespace Ch101.Var
{
    class Program
    {
        static void Main(string[] args)
        {
            var actionList = new Dictionary<string, Action<TextWriter>>();

            actionList.Add("Sample01", (writer) => { writer.WriteLine("I'm Sample 01!"); });
            actionList.Add("Sample02", (writer) => { writer.WriteLine("I'm Sample 02!"); });

            foreach (var item in actionList.Values)
            {
                item(Console.Out);
            }

            Console.ReadLine();
        }
    }
}
