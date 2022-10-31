using ESerializerTests.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESerializerTests.Models
{
    public class Settings
    {
        public NetworkSettings NetworkSettings { get; set; }

        public static Settings Default
        {
            get => new Settings()
            {
                NetworkSettings = new NetworkSettings()
                {
                    LocalAddress = new IPSimpleEndPoint("192.168.3.107", 11006),
                    RemoteAddress = new IPSimpleEndPoint("192.168.3.1", 11001)
                }
            };
        }
    }
}
