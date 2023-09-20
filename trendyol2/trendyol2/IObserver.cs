using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static trendyol2.UartServer;

namespace trendyol2
{
    internal interface IObserver
    {
        public void update();
    }
}
