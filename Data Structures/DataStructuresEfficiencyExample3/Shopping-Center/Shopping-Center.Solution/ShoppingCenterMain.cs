using System;
using System.Globalization;
using System.Threading;

namespace ShoppingCenter
{
    public class ShoppingCenterMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var center = new ShoppingCenterSlow();

            int commands = int.Parse(Console.ReadLine());
            for (int i = 1; i <= commands; i++)
            {
                string command = Console.ReadLine();
                string commandResult = center.ProcessCommand(command);
                Console.WriteLine(commandResult);
            }
        }
    }
}
