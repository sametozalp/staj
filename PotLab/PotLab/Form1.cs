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
            observer = new ProductObserver(scope1);
            subject = new ProductSubject();
            subject.subscribe(observer);

            scope1.XAxis.CustomLabel += scope1_XAxis_CustomLabel; // X koordinatının datetime tipinde geleceğini söyler
        }
        private Product initializeProduct()
        {
            Product product = new Product();
            product.productNo = 10;
            product.price = changePrice();
            product.date = DateTime.Now;
            return product;
        }

        private Random random;
        private int newPrice;
        private int changePrice()
        {
            random = new Random();
            newPrice = random.Next(20000) + 10;
            return newPrice;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                product.price = changePrice();
                product.date = DateTime.Now;
                subject.priceControl(product);
            }
        }

        private void scope1_XAxis_CustomLabel(object sender, Mitov.PlotLab.CustomAxisLabelEventArgs Args)
        {
            Args.AxisLabel = System.DateTime.FromBinary((long)Math.Round(Args.SampleValue)).ToShortDateString();
        }
    }
}
