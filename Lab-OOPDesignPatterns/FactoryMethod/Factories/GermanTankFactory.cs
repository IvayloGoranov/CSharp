using TankManufacturer.Units;

namespace TankManufacturer.Factories
{
    public class GermanTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            string model = "Tiger";
            double speed = 4.5;
            int damage = 120;

            Tank tiger = new Tank(model, speed, damage);

            return tiger;
        }
    }
}
