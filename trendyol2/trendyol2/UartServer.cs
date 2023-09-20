using System;
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
            byte[] receivedData = new byte[Marshal.SizeOf<Product>()];
            while (true)
            {
                serialPort.Read(receivedData, 0, receivedData.Length);

                Product product = byteArrayToStructure(receivedData);
                Console.WriteLine($"Name: {product.name}, Price: {Convert.ToString(product.price)}");

                Thread.Sleep(1000);
            }
        }
        //******************************************
        public static Product byteArrayToStructure(byte[] receivedData)
        {
            Product product = new Product();
 
            GCHandle handle = GCHandle.Alloc(receivedData, GCHandleType.Pinned);
            try
            {
                product = (Product)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Product));
                return product;
            }
            finally
            {
                handle.Free();
            }
        }
        //******************************************
        public struct Product
        {
            public int productNo;
            public int price;
            public long Timestamp;
        }
    }
}
