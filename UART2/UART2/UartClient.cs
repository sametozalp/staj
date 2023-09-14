using System;
using System.IO.Ports;

namespace UART2
{
    public class UartClient
    {
        SerialPort serialPort;
        public UartClient(string portName, int baudRate)
        {
            serialPort = new SerialPort(portName, baudRate,Parity.Mark,8, StopBits.One);
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

        public void sendData(String data)
        {
            try
            {
                serialPort.WriteLine(data);
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
