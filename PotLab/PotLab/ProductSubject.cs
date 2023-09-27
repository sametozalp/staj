using System;
using System.Collections.Generic;

namespace PotLab
{
    internal class ProductSubject
    {
        List<ProductObserver> observers = new List<ProductObserver>();
        public void subscribe(ProductObserver observer)
        {
            observers.Add(observer);
        }

        public void unSubscribe(ProductObserver observer)
        {
            observers.Remove(observer);
        }

        public void notify(Product product)
        {
            foreach(var observer in observers)
            {
                observer.update(product);
            }
        }

        public void priceControl(Product product)
        {
            if(product.price != tempPrice)
            {
                tempPrice = product.price;
                notify(product);
            }
        }
        private int tempPrice;

        public void changePriceAndDateTime(ref Product product)
        {
            for (int i = 0; i < 100; i++)
            {
                product.price = changePrice();
                product.date = product.date.AddHours(1);
                priceControl(product);
            }
        }
        private Random random = new Random();
        public int changePrice()
        {
            return random.Next(20000) + 10;
        }
    }
}
