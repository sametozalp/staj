using System;
using System.IO.Ports;

namespace UART1
{
    public class UartServer
    {
        SerialPort serialPort;
        public UartServer(String portName, int baudRate)
        {
            serialPort = new SerialPort(portName, baudRate, Parity.Odd,8,StopBits.Two);
        }

        public void open()
        {
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void close()
        {
            try
            {
                serialPort.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void getData()
        {
            while (true)
            {
                string data = serialPort.ReadLine();
                Console.WriteLine(data);
            }
        }
    }
}
