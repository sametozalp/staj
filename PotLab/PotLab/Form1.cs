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
        private void scope1_Channels0_ChannelDraw(object sender, Mitov.PlotLab.ChannelDrawEventArgs e)
        {
            if (!e.WasChanged)
                return;

            Mitov.PlotLab.ScopeChannelMarker AMarker;
            double MaxValue = -20000;
            double MinValue = 20000;
            int MinPosition = 0;
            int MaxPosition = 0;
            scope1.Channels[0].DrawMarkers.Clear();
            for (int i = 0; i < e.DataSize; i++)
            {
                double DataItem = e.ChannelData[i];
                if (MaxValue < DataItem)
                {
                    MaxValue = DataItem;
                    MaxPosition = i;
                }

                if (MinValue > DataItem)
                {
                    MinValue = DataItem;
                    MinPosition = i;
                }

                if (DataItem > 9000)
                {
                    AMarker = new Mitov.PlotLab.ScopeChannelMarker();
                    AMarker.MarkerGroupIndex = 2;
                    AMarker.Position = i;
                    scope1.Channels[0].DrawMarkers.Add(AMarker);
                }

                if (DataItem < -9000)
                {
                    AMarker = new Mitov.PlotLab.ScopeChannelMarker();
                    AMarker.MarkerGroupIndex = 3;
                    AMarker.Position = i;
                    scope1.Channels[0].DrawMarkers.Add(AMarker);
                }
            }

            AMarker = new Mitov.PlotLab.ScopeChannelMarker();
            AMarker.Position = MaxPosition;
            AMarker.MarkerGroupIndex = 0;
            scope1.Channels[0].DrawMarkers.Add(AMarker);

            AMarker = new Mitov.PlotLab.ScopeChannelMarker();
            AMarker.Position = MinPosition;
            AMarker.MarkerGroupIndex = 1;
            scope1.Channels[0].DrawMarkers.Add(AMarker);
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

        List<double> buffer1 = new List<double>();
        List<double> buffer2 = new List<double>();
        private void timer2_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < 10000; i++)
            {
                product.price = changePrice();
                product.Timestamp = firstZero(DateTime.Now.Ticks);
                subject.priceControl(product);
                buffer1.Add(observer.updatePrice());
                buffer2.Add(observer.updateTimestamp());
                //scope1.Channels[1].Data.AddXYPoint(buffer1.ToArray()[i], buffer2.ToArray()[i]);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            scope1.XInputPins.Add(100);

            scope1.Channels[0].Data.AddYData(buffer1.ToArray());
            //scope1.Channels[1].Data.AddYData(buffer2.ToArray());
            //scope1.Channels[1].Data.AddXYData(buffer2.ToArray(), buffer1.ToArray());
            scope1.Channels[0].ChannelDraw += scope1_Channels0_ChannelDraw;
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
            return 0;
        }

    }
}
