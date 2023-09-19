using System;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;

namespace trendyol2
{
    public class UartServer
    {
        SerialPort serialPort;
        public UartServer(String portName, int baudRate)
        {
            serialPort = new SerialPort(portName, baudRate);
        }
        //******************************************
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
        //******************************************
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
        //******************************************
        public void getByte()
        {
            byte[] receivedData = new byte[Marshal.SizeOf(typeof(Product))];

            while (true)
            {
                serialPort.Read(receivedData, 0, receivedData.Length);

                //Console.WriteLine(BitConverter.ToString(receivedData));

                Product product = byteArrayToStruct(receivedData);

                Console.WriteLine(product.name);

                Thread.Sleep(1000);
            }
        }
        //******************************************
        private Product byteArrayToStruct(byte[] receivedData)
        {
            Product product = new Product();

            GCHandle handle = GCHandle.Alloc(receivedData, GCHandleType.Pinned); // pointer

            product = (Product)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Product));

            handle.Free();

            return product;
        }
        //******************************************
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Product
        {
            public string name;
            public int price;
        }
    }
}
