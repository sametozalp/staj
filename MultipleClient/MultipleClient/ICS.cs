using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MultipleClient
{
    internal interface ICS
    {
        void execute(IPAddress ipAdress, int port);
    }
}
