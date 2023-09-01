using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace UDPP
{
    internal interface ICS
    {
        void execute(IPAddress ipAdress, int port);
    }
}
