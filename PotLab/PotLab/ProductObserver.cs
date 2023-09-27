using Mitov.PlotLab;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PotLab
{
    internal class ProductObserver
    {
        private Product product;
        private Scope scope1;
        public ProductObserver(Scope scope1)
        {
            this.scope1 = scope1;
        }
        
        public void update(Product product)
        {
            Console.WriteLine($"Prudoct No: {product.productNo} numaralı ürünün yeni fiyatı: {product.price} olarak güncellendi. Timetamp: {product.date} ");
            this.product = product;
            draw();
        }

        private void draw()
        {
            scope1.Channels[0].Data.AddXYPoint(updateHours().ToBinary(), updatePrice());
        }

        public int updatePrice()
        {
            return product.price;
        }

        public DateTime updateHours()
        {
            return product.date;
        }
    }
}
