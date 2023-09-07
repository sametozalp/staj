using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Runtime.InteropServices;
using UDPP;
using System.Threading;

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
                    Base.MyData myData = ConvertByteArrayToByteArray(receivedMessage);
                    Console.WriteLine("Mesaj alındı. Mesaj: ");
                    for(int i = 0; i<receivedMessage.Length; i++)
                    {
                        Console.WriteLine(myData.data[i]);
                    }
                    Thread.Sleep(1);
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

        public Base.MyData ConvertByteArrayToByteArray(byte[] byteArray)
        {
            Base.MyData myData = new Base.MyData();
            //byte arrayi sabitlenmiş bir işaretçiye dönüştürüyoruz. (GCHandleType.Pinned)
            GCHandle handle = GCHandle.Alloc(byteArray, GCHandleType.Pinned); // pointer
            try
            {
                //burda da byte dizisini tekrar struct yapısına çeviriyoruz.
                //handle.AddrOfPinnedObject() pointerın adresini alır.
                myData = (Base.MyData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Base.MyData));
            }
            finally
            {
                handle.Free(); // pointerı serbest bırakıyoruz.
            }

            return myData;
        }
    }
}