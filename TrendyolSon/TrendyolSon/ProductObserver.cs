using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TrendyolSon
{
    internal class ProductObserver
    {
        
        public void update(Product product)
        {
            Console.WriteLine($"Prudoct No: {product.productNo} numaralı ürünün yeni fiyatı: {product.price} olarak güncellendi. Timetamp: {product.Timestamp} ");

        }
    }
}
