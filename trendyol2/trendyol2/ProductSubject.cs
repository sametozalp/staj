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
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].productNo == product.productNo && products[i].price != product.price)
                {
                    products[i] = product;
                    break;
                }
            }
        }
    }
}
