namespace Prototype
{
    using System;

    public class Program
    {
        static void Main()
        {
            var darkTrooper = new Stormtrooper("Dark trooper", 180, 80);
            Stormtrooper anotherDarkTrooper = darkTrooper;
            darkTrooper.Height = 200;

            Console.WriteLine(darkTrooper);
            Console.WriteLine(anotherDarkTrooper);
        }
    }
}
