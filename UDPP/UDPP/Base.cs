using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace UDPP
{
    public class Base
    {
        string path = @"C:\Users\Samet\Desktop\UDPP\UDPP\config.txt";
        string ip = "";
        string port = "";

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

        public IPAddress GetIPAdress()
        {
            return IPAddress.Parse(ip); ;
        }
        public int GetPort()
        {
            return Convert.ToInt32(port);
        }
    }            
}
