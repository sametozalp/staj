using System;
using System.Collections.Generic;
using static trendyol2.UartServer;

namespace trendyol2
{
    internal class ProductSubject : ISubject
    {
        public static List<Product> products = new List<Product>();

        public void register(Product product)
        {
            if(products.Count == 0)
            {
                products.Add(product);
            }
            else
            {
                foreach (Product item in products)
                {
                    if (!(item.productNo == product.productNo))
                    {
                        products.Add(item);
                    }
                }
            }
        }

        public void remove(Product product)
        {
            products.Remove(product);
        }

        public void notify(Product product)
        {
            foreach (Product item in products)
            {
                if ((item.productNo == product.productNo) && (item.price != product.price))
                {
                    products.Add(item);
                }
            }
        }
    }
}
