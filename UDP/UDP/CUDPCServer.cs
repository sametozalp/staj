using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP
{
    public class CUDPServer
    {
        public void main(string[] args)
        {
            IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
            int port = 12345;
            bool done = false;

            try
            {
                Console.WriteLine("Server başlatılıyor..");
                UdpClient listener = new UdpClient();
                IPEndPoint listenEndPoint = new IPEndPoint(ipAdress, port);
                listener.Client.Bind(listenEndPoint);

                while (!done)
                {
                    Console.WriteLine("Mesaj alınıyor..");
                    byte[] receivedMessage = new byte[4 * 1024];
                    receivedMessage = listener.Receive(ref listenEndPoint);
                    Console.WriteLine(Encoding.ASCII.GetString(receivedMessage));
                }
                Console.WriteLine("Server kapatılıyor..");
                listener.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
