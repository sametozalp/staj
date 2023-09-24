using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using UDPP;
using System.Threading;

namespace MultipleClient
{
    internal class MultipleClient
    {
        Base.Insan insan = new Base.Insan();

        public void execute(IPAddress ipAdress, int port)
        {
            init();

            UdpClient client = client = new UdpClient(); ;
            
            try
            {
                Console.WriteLine("Client başlatılıyor..");
                while(true)
                {
                    byte[] byteArray = ConvertToByteArray(insan);
                    client.Send(byteArray, byteArray.Length, Convert.ToString(ipAdress), port);
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

        public static byte[] ConvertToByteArray(Base.Insan insan)
        {
            int structSize = Marshal.SizeOf(insan);
            byte[] byteArray = new byte[structSize];

            IntPtr structPtr = Marshal.AllocHGlobal(structSize); // pointer
            Marshal.StructureToPtr(insan, structPtr, false); //yapıyı pointerın belirlediği yere yerleştirir.
                                                             //false, yönlendirme işlemidir.
            Marshal.Copy(structPtr, byteArray, 0, structSize); //yapıyı byteArray'in içerisine atar.
            Marshal.FreeHGlobal(structPtr); //belleği salar.

            return byteArray;
        }

        private void init()
        {
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
        }      
    }
}
