using System;
using Buhtig.Interfaces;

namespace Buhtig.UI
{
    public class InputHandler : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
