using RPG.Interfaces;

namespace RPG.Characters
{
    public class Mage : Character
    {
        public Mage(string name, int health, IWeapon weapon)
            : base(name, health, weapon)
        {
        }
    }
}
