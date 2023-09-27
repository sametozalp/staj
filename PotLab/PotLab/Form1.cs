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

            observer = new ProductObserver(scope1);
            subject = new ProductSubject();
            subject.subscribe(observer);
            product = initializeProduct();

            scope1.XAxis.CustomLabel += scope1_XAxis_CustomLabel; // X koordinatının datetime'a göre düzenler.
        }
        private Product initializeProduct()
        {
            Product product = new Product();
            product.productNo = 10;
            product.price = subject.changePrice();
            product.date = DateTime.Now;
            return product;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            subject.changePriceAndDateTime(ref product);
        }

        // X ekseni için özel isimler verilmesini sağlayan fonksiyon
        private void scope1_XAxis_CustomLabel(object sender, Mitov.PlotLab.CustomAxisLabelEventArgs Args)
        {
            double point = Args.SampleValue; // X ekseni üzerindeki noktanın değerini temsil eder.
            DateTime newXPointDateTime = DateTime.FromBinary((long)Math.Round(point)); // tarihi alır yuvarlar
            Args.AxisLabel = newXPointDateTime.ToShortTimeString(); // tarihi x eksenine atar
        }
    }
}
