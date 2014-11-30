using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace CSVFileWatcher
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern void AllocConsole();
        static void Main(string[] args)
        {

            var service = new CSVFileWatcherService();
            service.Directory = @"C:\";
            service.FilesMask = "*.csv";
            if (Environment.UserInteractive)
            {
                AllocConsole();
                Console.CancelKeyPress += (x, y) => service.Stop();
                service.Start();
                Console.ReadKey();
                service.Stop();
            }
            else
            {
                ServiceBase.Run(service);
            }
        }
    }
}
