using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace trendyol1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UartClient client = new UartClient("COM3", 9600);
            client.open();

            Product product = new Product();
            product.productNo = 10;
            
            while (true)
            {
                product.price = changePrice();
                byte[] byteArray = structToByteArray(product);

                client.sendByteArray(byteArray);
                Thread.Sleep(1000);
            }

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
            public int productNo;
            public int price;
            public long Timestamp;
        }
        //******************************************
        private static int changePrice()
        {
            Random random = new Random();
            int price = random.Next(100) + 10;
            Thread.Sleep(1000);

            return price;
        }
    }
}