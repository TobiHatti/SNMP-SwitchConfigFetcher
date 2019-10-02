using SnmpSharpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_Analyser
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] ipAddresses = new string[]
            {
                "10.1.38.30",
            };

            Switch s1;
            foreach (string ip in ipAddresses)
            {
                try
                {
                    Console.WriteLine("=============================================");
                    Console.WriteLine($"=== {ip} =============================");
                    Console.WriteLine("=============================================");
                    s1 = new Switch(ip);
                    foreach (Interface ifc in s1.Interfaces)
                        Console.WriteLine(ifc.ToString());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Could not connect to Host!");
                }
            }

        }
    }
}
