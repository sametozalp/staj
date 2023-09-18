using System;
using System.Collections;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace trendyol2
{
    public class UartServer
    {
        SerialPort serialPort;
        public UartServer(String portName, int baudRate)
        {
            serialPort = new SerialPort(portName, baudRate, Parity.Odd, 8, StopBits.Two);
        }

        public void open()
        {
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void close()
        {
            try
            {
                serialPort.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void getByte()
        {
            while (true)
            {
                byte[] receivedData = new byte[30]; // Alınacak veri için bir byte dizisi tanımlayın
                serialPort.Read(receivedData, 0, receivedData.Length);

                //Console.WriteLine(BitConverter.ToString(receivedData));

                byteArrayToStruct(receivedData);

                Thread.Sleep(1000);
            }
        }

        public void byteArrayToStruct(byte[] byteArray)
        {
            Product product = new Product();

            //byte arrayi sabitlenmiş bir işaretçiye dönüştürüyoruz. (GCHandleType.Pinned)
            GCHandle handle = GCHandle.Alloc(byteArray, GCHandleType.Pinned); // pointer
            //burda da byte dizisini tekrar struct yapısına çeviriyoruz.
            //handle.AddrOfPinnedObject() pointerın adresini alır.
            product = (Product)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Product));

            handle.Free(); // pointerı serbest bırakıyoruz.

            Console.WriteLine(product.name);
        }

        struct Product
        {
            public string name;
            public int price;
            public DateTime dateTime;
        }

    }
}
