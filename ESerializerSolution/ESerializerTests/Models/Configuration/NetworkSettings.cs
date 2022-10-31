using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESerializerTests.Models.Configuration
{
    public class NetworkSettings
    {
        public IPSimpleEndPoint LocalAddress { get; set; }

        public IPSimpleEndPoint RemoteAddress { get; set; }
    }
}
