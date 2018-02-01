namespace RPG
{
    using System;

    using RPG.Characters;
    using RPG.Weapons;

    public class Program
    {
        static void Main()
        {
            Warrior axeWarrior = new Warrior("Pesho", 20, new Axe(2));
            Warrior swordWarrior = new Warrior("Gosho", 20, new Sword(3));
            Mage axeMage = new Mage("Tsetso", 20, new Axe(2));
            Mage swordMage = new Mage("Joro", 20, new Sword(2));

            Console.WriteLine(axeWarrior);
            Console.WriteLine(swordMage);

            axeWarrior.Attack(swordMage);

            Console.WriteLine(axeWarrior);
            Console.WriteLine(swordMage);
        }
    }
}
