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
        Base.MyData myData = new Base.MyData();

        public void execute(IPAddress ipAdress, int port)
        {
            init();

            UdpClient client = client = new UdpClient(); ;
            
            try
            {
                    Console.WriteLine("Client başlatılıyor..");
                    byte[] byteArray = ConvertToByteArray(myData);
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

        public static byte[] ConvertToByteArray(Base.MyData myData)
        {
            int structSize = Marshal.SizeOf(myData);
            byte[] byteArray = new byte[structSize];

            IntPtr structPtr = Marshal.AllocHGlobal(structSize); // pointer
            Marshal.StructureToPtr(myData, structPtr, false); //yapıyı pointerın belirlediği yere yerleştirir.
                                                             //false, yönlendirme işlemidir.
            Marshal.Copy(structPtr, byteArray, 0, structSize); //yapıyı byteArray'in içerisine atar.
            Marshal.FreeHGlobal(structPtr); //belleği salar.

            return byteArray;
        }

        private void init()
        {
            myData.data = new uint[10];
            for(int i = 0; i < myData.data.Length; i++)
            {
                myData.data[i] = Convert.ToUInt32(i);
            }
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

      
    }
}
