using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESerializerLib.Services.Interfaces
{
    public interface IDebugger
    {
        void Print(string message, ConsoleColor color);
    }
}
