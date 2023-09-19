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
            byte[] receivedData = new byte[Marshal.SizeOf<Product>()];
            while (true)
            {
                serialPort.Read(receivedData, 0, receivedData.Length);

                Product receivedPacket = byteArrayToStructure(receivedData);

                Console.WriteLine($"Received Data - Timestamp: {receivedPacket.Timestamp}, Data1: {receivedPacket.name}, Data2: {receivedPacket.price}");
                Thread.Sleep(1000);
            }
        }
        //******************************************
        public static Product byteArrayToStructure(byte[] receivedData)
        {
            Product uartData = new Product();

            GCHandle handle = GCHandle.Alloc(receivedData, GCHandleType.Pinned);
            try
            {
                uartData = (Product)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Product));
                return uartData;
            }
            finally
            {
                handle.Free();
            }
        }
        //******************************************
        public struct Product
        {
            public int name;
            public int price;
            public long Timestamp;
        }
    }
}
