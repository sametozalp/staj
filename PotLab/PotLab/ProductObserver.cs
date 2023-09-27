using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PotLab
{
    internal class ProductObserver
    {
        Product product;
        public void WriteUpdate(Product product)
        {
            Console.WriteLine($"Prudoct No: {product.productNo} numaralı ürünün yeni fiyatı: {product.price} olarak güncellendi. Timetamp: {product.date} ");
            this.product = product;
            
        }

        public int updatePrice()
        {
            return product.price;
        }

        public DateTime updateTimestamp()
        {
            Console.WriteLine(product.date);
            return product.date;
        }

        public void addDay(int day)
        {
            this.product.date.AddDays(day);
        }
    }
}
