using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Runtime.InteropServices;

namespace MultipleClient
{
    internal class Server
    {
        public struct Erkek
        {
            public string isim;
            public int sac;
            public long makyaj;
            public sbyte sesFrekans;
        }
        public struct Kadin
        {
            public string isim;
            public int sac;
            public long makyaj;
            public sbyte sesFrekans;
        }
        public struct Insan
        {
            public Erkek mehmet;
            public Kadin ayse;
        }

        public void execute(IPAddress ipAdress, int port)
        {
            UdpClient listener = new UdpClient();

            try
            {
                Console.WriteLine("Server başlatılıyor..");
                IPEndPoint ep = new IPEndPoint(ipAdress, port);
                listener.Client.Bind(ep);

                while (true)
                {
                    Console.WriteLine("Mesaj bekleniyor..");
                    byte[] receivedMessage = listener.Receive(ref ep);
                    Insan insan = ConvertByteArrayToStruct(receivedMessage);
                    Console.WriteLine("Mesaj alındı. Mesaj: \n" 
                        + "Erkek isim: " + insan.mehmet.isim
                       + "\nSac: " + (insan.mehmet.sac == 1 ? "Uzun sac" : "Kısa sac")
                       + "\nMakyaj: " + (insan.mehmet.makyaj == 0 ? "Makyaj yapmaz" : "Makyaj yapar")
                       + "\nSes: " + (insan.mehmet.sesFrekans == 1 ? "İnce ses" : "Kalın ses")
                       + "\nKiz isim: " + insan.ayse.isim
                       + "\nSac: " + (insan.ayse.sac == 1 ? "Uzun sac" : "Kısa sac")
                       + "\nMakyaj: " + (insan.ayse.makyaj == 0 ? "Makyaj yapmaz" : "Makyaj yapar")
                       + "\nSes: " + (insan.ayse.sesFrekans == 1 ? "İnce ses" : "Kalın ses"));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Server kapatılıyor..");
                listener.Close();
            }
        }

        public Insan ConvertByteArrayToStruct(byte[] byteArray)
        {
            Insan insan = new Insan();

            GCHandle handle = GCHandle.Alloc(byteArray, GCHandleType.Pinned);
            try
            {
                insan = (Insan)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Insan));
            }
            finally
            {
                handle.Free();
            }

            return insan;
        }
    }
}