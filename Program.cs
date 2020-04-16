using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using UACHelper;

namespace Reset_WifiAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows) && IsAdministrator())
            {
                Console.WriteLine("Disabling Wifi Adapter");

                // disable wifi
                DisableAdapter("Wi-Fi");

                Thread.Sleep(2000); // sleep for 2 seconds

                Console.WriteLine("Enable Wifi Adapter");

                // enable wifi
                EnableAdapter("Wi-Fi");

                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("This application has to be run as an Administrator");
            }

            Console.WriteLine("Press Any Key to Quit");
            Console.ReadKey();
        } 

        private static bool IsAdministrator()
        {
            return (new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent())).IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        static void EnableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }

        static void DisableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
    }
}
