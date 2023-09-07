using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Runtime.InteropServices;
using UDPP;

namespace MultipleClient
{
    internal class Server
    {
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
                    Base.Insan insan = ConvertByteArrayToStruct(receivedMessage);
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

        public Base.Insan ConvertByteArrayToStruct(byte[] byteArray)
        {
            Base.Insan insan = new Base.Insan();
            //byte arrayi sabitlenmiş bir işaretçiye dönüştürüyoruz. (GCHandleType.Pinned)
            GCHandle handle = GCHandle.Alloc(byteArray, GCHandleType.Pinned); // pointer
            try
            {
                //burda da byte dizisini tekrar struct yapısına çeviriyoruz.
                //handle.AddrOfPinnedObject() pointerın adresini alır.
                insan = (Base.Insan)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Base.Insan));
            }
            finally
            {
                handle.Free(); // pointerı serbest bırakıyoruz.
            }

            return insan;
        }
    }
}