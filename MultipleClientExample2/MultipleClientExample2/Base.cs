using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace UDPP
{
    public class Base
    {
        private string path = @"C:\Users\Samet\Desktop\MultipleClient\MultipleClient\config.txt";
        private string ip = "";
        private string port = "";

        public Base() {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string satir;

                    while ((satir = reader.ReadLine()) != null)
                    {
                        if (ip.Equals(""))
                        {
                            ip = satir;
                        }
                        else
                        {
                            port = satir;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }

        public IPAddress getIPAdress()
        {
            return IPAddress.Parse(ip); ;
        }
        public int getPort()
        {
            return Convert.ToInt32(port);
        }

       public struct MyData
        {
            public UInt32[] data;
        }
    }            
}
