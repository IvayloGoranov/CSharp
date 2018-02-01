using System;
using Buhtig.Interfaces;

namespace Buhtig.UI
{
    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string message, params string[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}
