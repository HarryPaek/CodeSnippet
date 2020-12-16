using System;
using System.Globalization;

namespace LocalDateTimeFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            SetUICulture();

            DateTime now = DateTime.Now;

            Console.WriteLine("Now = [{0}]", now.ToString());

            Console.ReadLine();
        }

        private static void SetUICulture()
        {
            try
            {
                // var newCulture = new CultureInfo("en-GB");
                // var newCulture = new CultureInfo("en-GB");
                var newCulture = new CultureInfo("en-US");

                //Culture for any thread
                CultureInfo.DefaultThreadCurrentCulture = newCulture;

                //Culture for UI in any thread
                CultureInfo.DefaultThreadCurrentUICulture = newCulture;
            }
            catch
            {
            }
        }

    }
}
