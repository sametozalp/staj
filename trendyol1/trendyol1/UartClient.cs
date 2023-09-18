using System;
using System.IO.Ports;

namespace trendyol1
{
    public class UartClient
    {
        SerialPort serialPort;
        public UartClient(string portName, int baudRate)
        {
            serialPort = new SerialPort(portName, baudRate, Parity.Mark, 8, StopBits.One);
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
        
        public void sendString(String data)
        {
            try
            {
                serialPort.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void sendByteArray(byte[] byteArray)
        {
            try
            {
                serialPort.Write(byteArray,0,byteArray.Length);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
