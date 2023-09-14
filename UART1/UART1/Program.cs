using System;
using System.IO.Ports;

namespace UART1 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SerialPort.GetPortNames());
            SerialPort serialPort = new SerialPort("COM5",9600);

            try
            {
                serialPort.Open();

                while (true)
                {
                    string data = serialPort.ReadLine();
                    Console.WriteLine("Gelen veri " + data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                serialPort.Close();
            }
        }
    }
}
