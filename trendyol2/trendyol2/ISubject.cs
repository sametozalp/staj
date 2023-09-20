using static trendyol2.UartServer;

namespace trendyol2
{
    internal interface ISubject
    {
        public void notify(Product product);
        public void register(Product product);
        public void remove(Product product);

    }
}
