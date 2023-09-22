using System.Collections.Generic;

namespace PotLab
{
    internal class ProductSubject
    {
        List<ProductObserver> observers = new List<ProductObserver>();
        private int tempPrice;
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
    }
}
