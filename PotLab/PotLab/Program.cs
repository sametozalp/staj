using System;
using System.Threading;
using System.Windows.Forms;

namespace PotLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new Form1());
        }
    }
}

struct Product
{
    public int productNo;
    public int price;
    public Double Timestamp;
}
