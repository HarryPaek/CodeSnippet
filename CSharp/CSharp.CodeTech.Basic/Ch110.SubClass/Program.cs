using System;
using System.Collections.Generic;

namespace Ch110.SubClass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseShip> list = new List<BaseShip>(new BaseShip[] { new SubMarine(30), new Cruiser(10, 20) });
            int sum = 0;

            foreach (var item in list)
            {
                sum += item.Males;
            }

            Console.WriteLine("Males in ships are = [{0}]", sum);
            Console.ReadLine();
        }
    }

    internal class Cruiser : BaseShip
    {
        public int Females { get; private set; }

        public Cruiser(int males, int females)
        {
            this.Males = males;
            this.Females = females;
        }
    }

    internal class SubMarine : BaseShip
    {
        public SubMarine(int males)
        {
            this.Males = males;
        }
    }

    internal class BaseShip
    {
        public int Males { get; protected set; }
    }
}
