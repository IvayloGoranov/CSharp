namespace Skyrim
{
    using System.Collections.Generic;
    using System;

    using Skyrim.Units;
    using Skyrim.Items;

    class SkyrimMain
    {
        static void Main()
        {
            // Dragon with 100 HP
            var dragon = new Dragon("Alduin", 300, 100, new Weapon(10, 20));
            
            List<Warrior> warriors = new List<Warrior>();
            warriors.Add(new Warrior("Ulfric Stormcloak", 80, 80));
            warriors.Add(new Warrior("Cicero", 15, 50));
            warriors.Add(new Warrior("Jarl Balgruuf", 40, 30));

            dragon.Attach(warriors[0]);


            // Nothing happens
            dragon.HealthPoints -= 20;
            // Nothing happens
            dragon.HealthPoints -= 10;
            // Dragon dies
            dragon.HealthPoints -= 90;

            foreach (var item in warriors[0].Inventory)
            {
                Console.WriteLine(item);
            }
        }
    }
}
