namespace Skyrim.Units
{
    using System.Collections.Generic;

    using Skyrim.Items;
    using Skyrim.Interfaces;

    public class Warrior : Unit, IDragonDeathObserver
    {
        public Warrior(string name, int attackPoints, int healthPoints) 
            : base(name, attackPoints, healthPoints)
        {
            this.Inventory = new List<Weapon>();
        }

        public IList<Weapon> Inventory { get; private set; }

        public void Update(Weapon weapon)
        {
            this.Inventory.Add(weapon);
        }

        public override string ToString()
        {
            string output = string.Format("Name: {0}, Attack: {1}, Health {2}", 
                this.Name, this.AttackPoints, this.HealthPoints);
            
            return output;
        }
    }
}
