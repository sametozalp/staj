using System;
using System.Runtime.InteropServices;

namespace trendyol1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UartClient client = new UartClient("COM3", 9600);
            client.open();

            Product product = new Product();
            product.name = "Watch";
            product.price = 10;

            byte[] byteArray = structToByteArray(product);

            client.sendByteArray(byteArray);

            client.close();
        }
        //******************************************
        private static byte[] structToByteArray(Product product)
        {
            int productStructSize = Marshal.SizeOf(product);
            byte[] byteArray = new byte[productStructSize];

            IntPtr structPtr = Marshal.AllocHGlobal(productStructSize); // pointer
            Marshal.StructureToPtr(product, structPtr, false); // yapıyı pointerın belirlediği yere yerleştirir.
                                                               // false, yönlendirme işlemidir.
            Marshal.Copy(structPtr, byteArray, 0, productStructSize); // yapıyı byteArray'in içerisine atar.
            Marshal.FreeHGlobal(structPtr);

            return byteArray;
        }
        //******************************************
        struct Product
        {
            public string name;
            public int price;
        }
    }
}
/*
using System.IO.Ports;
using System.Runtime.InteropServices;
using System;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct UartData
{
    public long Timestamp;  // Timestamp in ticks (64-bit)
    public int Data1;
    public int Data2;
}
class UartClient
{
    static void Main(string[] args)
    {
        SerialPort serialPort = new SerialPort("COM4", 9600); // Replace "COM2" with your actual port name
        serialPort.Open();

        while (true)
        {
            // Prepare data to send (e.g., two integers and a timestamp)
            UartData sendData = new UartData
            {
                Timestamp = DateTime.UtcNow.Ticks, // Current timestamp in ticks
                Data1 = 42,
                Data2 = 84
            };

            // Convert data to byte array and send to the server
            byte[] sendDataBytes = StructureToByteArray(sendData);
            serialPort.Write(sendDataBytes, 0, sendDataBytes.Length);

            // Receive and process the response
            byte[] responseData = new byte[Marshal.SizeOf<UartData>()];
            serialPort.Read(responseData, 0, responseData.Length);

            // Deserialize the response data into the UartData struct
            UartData responsePacket = ByteArrayToStructure<UartData>(responseData);

            // Process the response data (e.g., print it)
            Console.WriteLine($"Received response: Timestamp={responsePacket.Timestamp}, Data1={responsePacket.Data1}, Data2={responsePacket.Data2}");
        }
    }

    // Helper method to convert byte array to structure
    static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
    {
        GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        try
        {
            return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
        }
        finally
        {
            handle.Free();
        }
    }

    // Helper method to convert structure to byte array
    static byte[] StructureToByteArray<T>(T structure) where T : struct
    {
        int size = Marshal.SizeOf(structure);
        byte[] bytes = new byte[size];
        IntPtr ptr = Marshal.AllocHGlobal(size);

        try
        {
            Marshal.StructureToPtr(structure, ptr, false);
            Marshal.Copy(ptr, bytes, 0, size);
        }
        finally
        {
            Marshal.FreeHGlobal(ptr);
        }

        return bytes;
    }

    // Helper methods (same as in UartServer)
    // ...
}
*/