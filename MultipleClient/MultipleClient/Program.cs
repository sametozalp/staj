using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UDPP;

namespace MultipleClient
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
            Thread thread3 = new Thread(method3);
            Thread thread4 = new Thread(method4);
            Thread thread5 = new Thread(method5);
            Thread thread6 = new Thread(method6);

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();

            void method1()
            {
                new Server().execute(ipAdress, port);
            }

            void method2()
            {
                Thread.Sleep(1000);
                new MultipleClient().execute(ipAdress, port);
            }
            void method3()
            {
               method2();
            }
            void method4()
            {
                method2();
            }
            void method5()
            {
                method2();
            }
            void method6()
            {
                method2();
            }

        }
    }
}
