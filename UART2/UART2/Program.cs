using System;
using System.IO.Ports;
using System.Threading;

namespace UART2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SerialPort serialPort = new SerialPort("COM3",9600);

            try
            {
                serialPort.Open();

                while (true)
                {
                    string data = "Hello world!!";
                    serialPort.Write(data);
                    Thread.Sleep(1000);
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
