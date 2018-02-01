using System.Globalization;
using System.Threading;
using Buhtig.Core;
using Buhtig.Interfaces;
using Buhtig.UI;

class Program
{
    static void Main()
    {
        //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        IRenderer renderer = new ConsoleRenderer();
        IInputHandler inputHandler = new InputHandler();
        IEngine engine = new Engine(renderer, inputHandler);
        engine.Run();
    }
 }
