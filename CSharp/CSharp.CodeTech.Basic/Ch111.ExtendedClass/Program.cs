using System;
using System.Collections.Generic;
using System.Linq;

namespace Ch111.ExtendedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Base> baseList = new List<Base>(new Base[] { new Base(), new Extended() });

            foreach (var item in baseList.OfType<Extended>())
            {
                item.SayIt();
            }
        }
    }

    internal class Extended : Base
    {
        public void SayIt()
        {
            Console.WriteLine("I am Extended!");
        }
    }

    internal class Base
    {
    }
}
