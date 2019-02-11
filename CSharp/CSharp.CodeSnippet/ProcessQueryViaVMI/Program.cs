using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ProcessQueryViaVMI
{
    class Program
    {
        static void Main(string[] args)
        {
            var wmiQueryString = "SELECT * FROM Win32_Process";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            using (var results = searcher.Get())
            {
                int index = -1;
                foreach (var result in results)
                {
                    index++;
                    ManagementObject mo = result as ManagementObject;

                    if(mo == null)
                        continue;

                    Console.WriteLine("ExecutablePath[{0}] = [{1}], CommandLine[{0}] = [{2}]", index, mo["ExecutablePath"], mo["CommandLine"]);
                }

                /*
                var query = from p in Process.GetProcesses()
                            join mo in results.Cast<ManagementObject>()
                            on p.Id equals (int)(uint)mo["ProcessId"]
                            select new
                            {
                                Process = p,
                                Path = (string)mo["ExecutablePath"],
                                CommandLine = (string)mo["CommandLine"],
                            };
                foreach (var item in query)
                {
                    // Do what you want with the Process, Path, and CommandLine
                }
                */
            }

            Console.WriteLine("Done!!!");
            Console.ReadLine();
        }
    }
}
