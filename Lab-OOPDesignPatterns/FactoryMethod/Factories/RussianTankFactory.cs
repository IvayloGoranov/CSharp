using TankManufacturer.Units;

namespace TankManufacturer.Factories
{
    public class RussianTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            string model = "T34";
            double speed = 3.3;
            int damage = 75;

            Tank t34 = new Tank(model, speed, damage);

            return t34;
        }
    }
}
