using System.Net;
using System.Text;
using System.Net.Sockets;
using System;
using UDPP;

namespace UDP
{
    public class CUDPClient : ICS
    {
        public void execute(IPAddress ipAdress, int port)
        {
            byte[] message;
            String keyboardData;

            try
            {
                Console.WriteLine("Client başlatılıyor..");
                UdpClient client = new UdpClient();
                while (true)
                {
                    Console.WriteLine("Mesaj giriniz:");
                    keyboardData = Console.ReadLine();
                    message = Encoding.ASCII.GetBytes(keyboardData);
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
