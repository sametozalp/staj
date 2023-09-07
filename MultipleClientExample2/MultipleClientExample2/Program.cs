using System.Net;
using System.Threading;
using UDPP;

namespace MultipleClient
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            //Marshal sınıfı, C# programlarında unmanaged (yönetilmeyen) kod ile
            //etkileşimde bulunmayı veya yönetilmeyen veri türlerini yönetilen
            //veri türlerine veya tam tersini dönüştürmeyi sağlayan
            //.NET Framework'ün bir parçasıdır.

            Base @base = new Base();
            IPAddress ipAdress = @base.getIPAdress();
            int port = @base.getPort();
            
            Thread thread1 = new Thread(method1);
            Thread thread2 = new Thread(method2);
            Thread thread3 = new Thread(method2);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            void method1()
            {
                new Server().execute(ipAdress, port);
            }

            void method2()
            {
                Thread.Sleep(1000);
                new MultipleClient().execute(ipAdress, port);
            }            
        }
    }
}
    