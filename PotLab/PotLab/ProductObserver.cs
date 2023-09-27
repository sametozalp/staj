using Mitov.PlotLab;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PotLab
{
    internal class ProductObserver
    {
        Product product;
        Mitov.PlotLab.Scope scope1;
        public ProductObserver(Mitov.PlotLab.Scope scope1)
        {
            this.scope1 = scope1;
        }
        
        public System.DateTime m_Date = System.DateTime.Today;
        private Random m_RandomGen = new Random(123);
        public void WriteUpdate(Product product)
        {
            Console.WriteLine($"Prudoct No: {product.productNo} numaralı ürünün yeni fiyatı: {product.price} olarak güncellendi. Timetamp: {product.date} ");
            this.product = product;

            //scope1.Channels[0].Data.AddXYPoint(updateTimestamp().ToBinary(), updatePrice());
            scope1.Channels[0].Data.AddXYPoint(m_Date.ToBinary(), updatePrice());
            m_Date = m_Date.AddDays(1);

        }

        public int updatePrice()
        {
            return product.price;
        }

        public DateTime updateTimestamp()
        {
            return product.date;
        }

        public void addDay(int day)
        {
            this.product.date.AddDays(day);
        }
    }
}
