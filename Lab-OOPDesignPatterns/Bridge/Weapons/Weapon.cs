using RPG.Interfaces;

namespace RPG.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public Weapon(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; private set; }
    }
}
