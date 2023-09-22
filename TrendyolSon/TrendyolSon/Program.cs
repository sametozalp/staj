using System;
using System.Threading;

namespace PotLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = initializeProduct();
            ProductObserver observer = new ProductObserver();
            ProductSubject subject = new ProductSubject();
            subject.subscribe(observer);

            while (true)
            {
                subject.priceControl(product);
                Thread.Sleep(1000);
                product.price = changePrice();
            }
        }

        private static Product initializeProduct()
        {
            Product product = new Product();
            product.productNo = 10;
            product.price = changePrice();
            product.Timestamp = DateTime.Now;
            return product;
        }

        private static Random random;
        private static int newPrice;
        private static int changePrice()
        { 
            random = new Random();
            newPrice = random.Next(100) + 10;
            return newPrice;
        }
    }
}

struct Product
{
    public int productNo;
    public int price;
    public DateTime Timestamp;
}
