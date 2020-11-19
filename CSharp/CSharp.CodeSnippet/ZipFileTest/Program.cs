using System;
using System.IO;
using ZipFileTest.Helpers;

namespace ZipFileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFolder = @"D:\EPLAN\ZipTest\Source";
            string targetFolderRoot = Path.GetTempPath();

            string zipFile = FileZipHelper.Zip(sourceFolder);

            string targetFolder = Path.Combine(targetFolderRoot, Path.GetRandomFileName());

            string upZipFolder = FileZipHelper.UpZip(zipFile, targetFolder);

            Console.WriteLine("Press <ENTER> to Quit...");
            Console.ReadLine();
        }
    }
}
