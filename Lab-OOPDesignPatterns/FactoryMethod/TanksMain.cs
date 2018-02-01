namespace TankManufacturer
{
    using System;

    using TankManufacturer.Units;
    using TankManufacturer.Factories;

    class TanksMain
    {
        static void Main()
        {
            TankFactory tankFactory = new GermanTankFactory();
            var tank1 = tankFactory.CreateTank();
            Console.WriteLine(tank1);

            tankFactory = new RussianTankFactory();
            var tank2 = tankFactory.CreateTank();
            Console.WriteLine(tank2);
            
            
            tankFactory = new AmericanTankFactory();
            var tank3 = tankFactory.CreateTank();
            Console.WriteLine(tank3);

        }
    }
}
