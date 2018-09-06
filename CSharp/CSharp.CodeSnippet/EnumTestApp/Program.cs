using EnumTestApp.AppClasses;
using EnumTestApp.Extensions;
using System;

namespace EnumTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colorStrings = { "0", "2", "8", "blue", "Blue", "Yellow", "Red, Green" };
            foreach (string colorString in colorStrings)
            {
                try
                {
                    LSCableDRMServiceReturnCode colorValue = (LSCableDRMServiceReturnCode)Enum.Parse(typeof(LSCableDRMServiceReturnCode), colorString);
                    if (Enum.IsDefined(typeof(LSCableDRMServiceReturnCode), colorValue) | colorValue.ToString().Contains(","))
                        Console.WriteLine("Converted '{0}' to {1}.", colorString, colorValue.ToString());
                    else
                        Console.WriteLine("{0} is not an underlying value of the Colors enumeration.", colorString);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("'{0}' is not a member of the Colors enumeration.", colorString);
                }
            }

            Console.In.ReadLine();

            foreach (string colorString in colorStrings)
            {
                LSCableDRMServiceReturnCode returnValue = EnumHelper.GetEnumValue<LSCableDRMServiceReturnCode>(colorString, LSCableDRMServiceReturnCode.Unknown);

                Console.WriteLine("Converted '{0}' to {1}.", colorString, returnValue.GetDescription());
            }

            Console.In.ReadLine();
        }
    }
}
