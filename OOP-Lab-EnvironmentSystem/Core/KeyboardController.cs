using EnvironmentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Core
{
    public class KeyboardController : IController
    {
        public event EventHandler Pause;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.Spacebar)
                {
                    if (this.Pause != null)
                    {
                        this.Pause(this, new EventArgs());
                    }
                }
            }
        }
    }
}
