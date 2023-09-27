using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PotLab
{
    internal class ProductObserver
    {
        Product product = new Product();
        public void WriteUpdate(Product product)
        {
            Console.WriteLine($"Prudoct No: {product.productNo} numaralı ürünün yeni fiyatı: {product.price} olarak güncellendi. Timetamp: {product.Timestamp} ");
            this.product = product;
            
        }

        public int updatePrice()
        {
            return product.price;
        }

        public double updateTimestamp()
        {
            return product.Timestamp;
        }
    }
}
