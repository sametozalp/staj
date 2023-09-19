using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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
            product.price = changePrice();

            byte[] byteArray = structToByteArray(product);
            client.sendByteArray(byteArray);

            client.close();
            
        }

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

        private static int changePrice()
        {
            return 10;
        }

        struct Product
        {
            public string name;
            public int price;
        }
    }
}