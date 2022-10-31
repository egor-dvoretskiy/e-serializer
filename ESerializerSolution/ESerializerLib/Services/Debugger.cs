using ESerializerLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESerializerLib.Services
{
    public class Debugger : IDebugger
    {
        public void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
