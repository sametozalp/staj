
using System.IO;
using System;
using System.Threading;
using UDP;
using System.Collections.Generic;
using System.Net;

namespace UDPP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Base @base = new Base();
            IPAddress ipAdress = @base.getIPAdress();
            int port = @base.getPort();

            Thread thread1 = new Thread(method1);
            Thread thread2 = new Thread(method2);

            thread1.Start();
            thread2.Start();

            void method1()
            {
                new CUDPServer().execute(ipAdress, port);
            }

            void method2()
            {
                Thread.Sleep(1000);
                new CUDPClient().execute(ipAdress, port);
            }
        }

        
    }
}
