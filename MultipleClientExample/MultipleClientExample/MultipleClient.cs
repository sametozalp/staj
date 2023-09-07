using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace MultipleClient
{
    internal class MultipleClient
    {
        public void execute(IPAddress ipAdress, int port)
        {

            Insan insan = new Insan();

            // Mehmet
            insan.mehmet.isim = "Mehmet";
            insan.mehmet.sac = 0;
            insan.mehmet.makyaj = 0;
            insan.mehmet.sesFrekans = 0;

            // Ayşe
            insan.ayse.isim = "Ayse";
            insan.ayse.sac = 1;
            insan.ayse.makyaj = 1;
            insan.ayse.sesFrekans = 1;

            UdpClient client = client = new UdpClient(); ;
            
            try
            {
                Console.WriteLine("Client başlatılıyor..");
                byte[] byteArray = ConvertToByteArray(insan);
                client.Send(byteArray, byteArray.Length, Convert.ToString(ipAdress), port);
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

        public static byte[] ConvertToByteArray(Insan insan)
        {
            int structSize = Marshal.SizeOf(insan);
            byte[] byteArray = new byte[structSize];

            IntPtr structPtr = Marshal.AllocHGlobal(structSize);
            Marshal.StructureToPtr(insan, structPtr, false);
            Marshal.Copy(structPtr, byteArray, 0, structSize);
            Marshal.FreeHGlobal(structPtr);

            return byteArray;
        }

        private void yazdir(String writing)
        {
            String writerPath = @"C:\\Users\\Samet\\Desktop\\MultipleClient\\MultipleClient\writing.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(writerPath, true))
                {
                    writer.WriteLine("Mesaj: " + writing + " Zaman: " + DateTime.Now);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }

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
    }
}
