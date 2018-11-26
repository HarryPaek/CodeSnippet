using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDefaultValue
{
    class Program
    {
        static void Main(string[] args)
        {
            EplanRepresentationType multiLine = EplanRepresentationType.MultiLine;
            EplanRepresentationType singleLine = EplanRepresentationType.SingleLine;
            EplanRepresentationType defaultValue = default(EplanRepresentationType);
            EplanRepresentationType newValue = new EplanRepresentationType();

            Console.WriteLine("multiLine = [{0}]", multiLine);
            Console.WriteLine("singleLine = [{0}]", singleLine);
            Console.WriteLine("defaultValue = [{0}]", defaultValue == null ? "NULL" : defaultValue.ToString());
            Console.WriteLine("newValue = [{0}]", newValue);

            Console.ReadLine();
        }
    }
}
