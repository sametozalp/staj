using System;

namespace Debug
{
    using System;
    using System.Threading;

    public class Program
    {
        static void Main(string[] args)
        {
            
            int[] array = new int[6];
            for (int i = 0; i < 5; i++) {
                array[i] = i*10;
            }

            //**************************************

            Thread thread = new Thread(fonk);
            thread.Start();

            
        }

        public static void fonk()
        {
            Console.WriteLine("Bolum Makinesi");

            Console.Write("Bolunen sayıyı girin: ");
            int sayi1 = 6;

            Console.Write("Bolen sayıyı girin: ");
            int sayi2 = 3;

            int bolum = sayi1 / sayi2;
            Console.WriteLine("Bolum: " + bolum);
        }
    }
}
