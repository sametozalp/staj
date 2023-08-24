using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPP;

namespace UDP
{
    public class CUDPServer : ICS
    {          

        public void execute()
        {
            Base @base = new Base();

            IPAddress ipAdress = @base.getIPAdress();
            int port = @base.getPort();
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
                    byte[] receivedMessage = new byte[4 * 1024];
                    receivedMessage = listener.Receive(ref ep);
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
