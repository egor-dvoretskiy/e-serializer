using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESerializerTests.Models.Configuration
{
    public class IPSimpleEndPoint
    {
        public string IP { get; set; }

        public int Port { get; set; }

        public IPSimpleEndPoint(string ip, int port)
        {
            this.Port = port;
            this.IP = ip;
        }

        public IPEndPoint GetAdvancedIPEndPoint() => new IPEndPoint(IPAddress.Parse(this.IP), this.Port);
    }
}
