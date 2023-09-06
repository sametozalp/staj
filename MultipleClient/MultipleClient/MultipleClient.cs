using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.IO;

namespace MultipleClient
{
    internal class MultipleClient
    {
        public void execute(IPAddress ipAdress, int port, String clientNo)
        {
            byte[] message;
            String keyboardData;
            UdpClient client = client = new UdpClient(); ;
            
            try
            {
                Console.WriteLine("Client başlatılıyor..");
                for (int i = 0; ; i++)
                {
                    keyboardData = i.ToString();
                    message = Encoding.ASCII.GetBytes(keyboardData + " (Client" + clientNo + ")");
                    client.Send(message, message.Length, Convert.ToString(ipAdress), port);
                    //yazdir(keyboardData);
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Client kapatılıyor..");
                client.Close();
            }
        }
        

        private void yazdir(String writing)
        {
            String writerPath = @"C:\\Users\\Samet\\Desktop\\MultipleClient\\MultipleClient\writing.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(writerPath, true))
                {
                    writer.WriteLine("Mesaj: "+ writing + " Zaman: " + DateTime.Now);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }
    }
}
