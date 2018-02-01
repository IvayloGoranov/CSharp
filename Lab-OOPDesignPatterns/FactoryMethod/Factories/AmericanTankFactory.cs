using TankManufacturer.Units;

namespace TankManufacturer.Factories
{
    public class AmericanTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            string model = "M1 Abrams";
            double speed = 5.4;
            int damage = 120;

            Tank abrams = new Tank(model, speed, damage);

            return abrams;
        }
    }
}
