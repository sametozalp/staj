using System.Threading;

namespace UART2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UartClient client = new UartClient("COM3", 9600);
            client.open();
            for (int i = 0; i<100; i++)
            {
                client.sendData("Hello World!!");
                Thread.Sleep(1000);
            }
            client.close();
            
        }
    }
}
