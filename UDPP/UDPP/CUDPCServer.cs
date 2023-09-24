using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPP;

namespace UDP
{
    public class CUDPServer : ICS
    {          
        public void execute(IPAddress ipAdress, int port)
        {
            UdpClient listener;

            try
            {
                Console.WriteLine("Server başlatılıyor..");
                listener = new UdpClient();
                IPEndPoint ep = new IPEndPoint(ipAdress, port);
                listener.Client.Bind(ep);

                while (true)
                {
                    Console.WriteLine("Mesaj bekleniyor..");
                    byte[] receivedMessage = listener.Receive(ref ep);
                    Console.WriteLine("Mesaj alındı. Mesaj: " + Encoding.ASCII.GetString(receivedMessage));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
