using System.Net;
using System.Text;
using System.Net.Sockets;
using System;
using UDPP;

namespace UDP
{
    public class CUDPClient : ICS
    {
        public void execute()
        {
            Base @base = new Base();
            IPAddress ipAdress = @base.getIPAdress();
            int port = @base.getPort();
            byte[] message;

            try
            {
                Console.WriteLine("Client başlatılıyor..");
                UdpClient client = new UdpClient();
                while (true)
                {
                    Console.WriteLine("Mesaj giriniz:");
                    String userData = Console.ReadLine();
                    message = Encoding.ASCII.GetBytes(userData);
                    Console.WriteLine("Mesaj gönderiliyor..");
                    client.Send(message, message.Length, Convert.ToString(ipAdress), port);
                    Console.WriteLine("Mesaj Gönderildi.");
                }
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
