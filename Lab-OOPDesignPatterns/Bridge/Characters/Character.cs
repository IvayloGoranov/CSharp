using RPG.Interfaces;

namespace RPG.Characters
{
    public abstract class Character : ICharacter
    {
        public Character(string name, int health, IWeapon weapon)
        {
            this.Name = name;
            this.Health = health;
            this.Weapon = weapon;
        }

        public IWeapon Weapon { get; set; }

        public string Name { get; set; }

        public int Health { get; set; }
        
        public void Attack(ICharacter target)
        {
            target.Health = target.Health - this.Weapon.Damage;
        }

        public override string ToString()
        {
            string output = string.Format("Name:{0}, Health: {1}", this.Name, this.Health);

            return output;
        }
    }
}
