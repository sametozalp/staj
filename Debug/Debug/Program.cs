using System;

namespace Debug
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hesap Makinesi");

            Console.Write("Bolunen sayıyı girin: ");
            int sayi1 = 6;
            
            Console.Write("Bolen sayıyı girin: ");
            int sayi2 = 3;

            int bolum = sayi1 / sayi2;
            Console.WriteLine("Bolum: " + bolum);
            */
            int[] array = new int[80];
            for (int i = 0; i < 10; i++) {
                array[i] = i*10;
            }
        }
    }
}
