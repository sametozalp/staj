using System.Net;
using System.Text;
using System.Net.Sockets;
using System;
using UDPP;

namespace UDP
{
    public class CUDPClient
    {
        public void execute()
        {
            Base @base = new Base();
            IPAddress ipAdress = @base.GetIPAdress();
            int port = @base.GetPort();
            byte[] message = Encoding.ASCII.GetBytes("Hello World");

            try
            {
                Console.WriteLine("Client başlatılıyor..");
                UdpClient client = new UdpClient();
                Console.WriteLine("Mesaj gönderiliyor..");
                client.Send(message, message.Length, Convert.ToString(ipAdress), port);
                Console.WriteLine("Mesaj Gönderildi.");
                Console.WriteLine("Client kapatılyor..");
                client.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
