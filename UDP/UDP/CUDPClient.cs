using System.Net;
using System.Text;
using System.Net.Sockets;
using System;

namespace UDP
{
    public class CUDPClient
    {

        public void main(string[] args)
        {
            IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
            int port = 12345;
            byte[] message = Encoding.ASCII.GetBytes("Hello World");

            try
            {
                Console.WriteLine("Client başlatılıyor..");
                UdpClient client = new UdpClient();
                IPEndPoint ep = new IPEndPoint(ipAdress, port);
                client.Client.Bind(ep);
                client.Connect(ep);
                Console.WriteLine("Mesaj gönderiliyor..");
                client.Send(message, message.Length);
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
