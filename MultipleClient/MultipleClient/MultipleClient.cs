using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace MultipleClient
{
    internal class MultipleClient
    {
        public void execute(IPAddress ipAdress, int port)
        {
            byte[] message;
            String keyboardData;

            try
            {
                Console.WriteLine("Client başlatılıyor..");
                UdpClient client = new UdpClient();
                for (int i = 0; ; i++)
                {
                    keyboardData = i.ToString();
                    message = Encoding.ASCII.GetBytes(keyboardData);
                    Console.WriteLine("Mesaj gönderiliyor..");
                    client.Send(message, message.Length, Convert.ToString(ipAdress), port);
                    Console.WriteLine("Mesaj Gönderildi.");
                    Thread.Sleep(1000);
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
