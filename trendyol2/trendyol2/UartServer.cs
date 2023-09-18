using System;
using System.IO;
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
            byte[] receivedData = new byte[24];

            while (true)
            {
                serialPort.Read(receivedData, 0, receivedData.Length);

                Console.WriteLine(BitConverter.ToString(receivedData));

                Product product = byteArrayToStruct(receivedData);
                Console.WriteLine(product.name);

                Thread.Sleep(1000);
            }
        }

        private Product byteArrayToStruct(byte[] receivedData)
        {
            Product product = new Product();

            //byte arrayi sabitlenmiş bir işaretçiye dönüştürüyoruz. (GCHandleType.Pinned)
            GCHandle handle = GCHandle.Alloc(receivedData, GCHandleType.Pinned); // pointer
            try
            {
                //burda da byte dizisini tekrar struct yapısına çeviriyoruz.
                //handle.AddrOfPinnedObject() pointerın adresini alır.
                product = (Product)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Product));

                Console.WriteLine(product.name);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }finally {
                handle.Free(); // pointerı serbest bırakıyoruz.
            }
            return product;
        }
        
        struct Product
        {
            public string name;
            public int price;
            public DateTime dateTime;
        }
    }
}
