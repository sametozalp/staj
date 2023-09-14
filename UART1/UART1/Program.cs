namespace UART1 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UartServer server = new UartServer("COM4",9600);
            server.open();
            server.getData();
            server.close();
        }
    }
}
