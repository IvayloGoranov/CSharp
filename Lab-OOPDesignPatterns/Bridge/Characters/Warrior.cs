using RPG.Interfaces;

namespace RPG.Characters
{
    public class Warrior : Character
    {
        public Warrior(string name, int health, IWeapon weapon)
            : base(name, health, weapon)
        {
        }
    }
}
