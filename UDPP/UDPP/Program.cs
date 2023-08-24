
using System.IO;
using System;
using System.Threading;
using UDP;
using System.Collections.Generic;

namespace UDPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Thread thread1 = new Thread(method1);
            Thread thread2 = new Thread(method2);

            thread1.Start();
            thread2.Start();
            
            void method1()
            {
                new CUDPServer().execute();
            }

            void method2()
            {
                Thread.Sleep(1000);
                new CUDPClient().execute();
            }
        }
    }
}
