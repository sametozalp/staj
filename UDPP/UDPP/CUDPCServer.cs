using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPP;

namespace UDP
{
    public class CUDPServer
    {          

        public void execute()
        {
            Base @base = new Base();

            IPAddress ipAdress = @base.GetIPAdress();
            int port = @base.GetPort();

            try
            {
                Console.WriteLine("Server başlatılıyor..");
                UdpClient listener = new UdpClient();
                IPEndPoint ep = new IPEndPoint(ipAdress, port);
                listener.Client.Bind(ep);

                while (true)
                {
                    Console.WriteLine("Mesaj bekleniyor..");
                    byte[] receivedMessage = new byte[4 * 1024];
                    receivedMessage = listener.Receive(ref ep);
                    Console.WriteLine("Mesaj alındı. Mesaj: " + Encoding.ASCII.GetString(receivedMessage));
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
