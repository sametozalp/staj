using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace PotLab
{
    public partial class Form1 : Form
    {
        Product product;
        ProductObserver observer;
        ProductSubject subject;
        public Form1()
        {
            InitializeComponent();

            product = initializeProduct();
            observer = new ProductObserver();
            subject = new ProductSubject();
            subject.subscribe(observer);

            
        }
        private static Product initializeProduct()
        {
            Product product = new Product();
            product.productNo = 10;
            product.price = changePrice();
            product.Timestamp = DateTime.Now.Ticks;
            return product;
        }

        private static Random random;
        private static int newPrice;
        private static int changePrice()
        {
            random = new Random();
            newPrice = random.Next(20000) + 10;
            return newPrice;
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            List<double> buffer1 = new List<double>();
            List<double> buffer2 = new List<double>();

            for (int i = 0; i < 1000; i++)
            {
                product.price = observer.updatePrice();
                product.Timestamp = firstZero(DateTime.Now.Ticks);
                subject.priceControl(product);
                buffer1.Add(observer.updatePrice());
                buffer2.Add(observer.updateTimestamp());
            }

            scope1.Channels[0].Data.AddYData(buffer1.ToArray());
            //scope1.Channels[1].Data.AddXYData(buffer1.ToArray(), buffer2.ToArray());

        }

        static long firstZero(long time)
        {
            string ticksStr = time.ToString();

            if (ticksStr.Length > 0)
            {
                ticksStr = "0" + ticksStr.Substring(1);
            }

            long newTicks;
            if (long.TryParse(ticksStr, out newTicks))
            {
                return newTicks;
            }
            else
            {
                throw new ArgumentException("Geçersiz Ticks değeri.");
            }
        }

    }
}
