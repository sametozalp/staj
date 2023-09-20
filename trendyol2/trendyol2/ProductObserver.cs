using System;
using System.Collections.Generic;
using static trendyol2.UartServer;
using static trendyol2.ProductSubject;

namespace trendyol2
{
    internal class ProductObserver : IObserver
    {
        public void update()
        {
            foreach(Product product in products)
            {
                Console.WriteLine(product.productNo + " nolu ürünün yeni fiyatı: " + product.price + " Timestamp: " + product.Timestamp);
            }
        }
    }
}
