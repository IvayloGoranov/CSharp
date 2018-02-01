using Skyrim.Interfaces;
using System.Collections.Generic;
using Skyrim.Items;

namespace Skyrim.Units
{
    public class Dragon : Unit, INotify
    {
        private List<IDragonDeathObserver> dragonDeathObservers;

        
        public Dragon(string name, int attackPoints, int healthPoints, Weapon weaponToDrop) 
            : base(name, attackPoints, healthPoints)
        {
            this.dragonDeathObservers = new List<IDragonDeathObserver>();
            this.WeaponToDrop = weaponToDrop;
        }

        public Weapon WeaponToDrop { get; set; }

        public override int HealthPoints
        {
            get
            {
                return base.HealthPoints;
            }
            set
            {
                base.HealthPoints = value;

                if (base.HealthPoints <= 0)
                {
                    this.Notify();
                }
            }
        }

        public void Attach(IDragonDeathObserver unit)
        {
            this.dragonDeathObservers.Add(unit);
        }

        public void Detach(IDragonDeathObserver unit)
        {
            this.dragonDeathObservers.Remove(unit);
        }

        public void Notify()
        {
            foreach (IDragonDeathObserver dragonDeathObserver in this.dragonDeathObservers)
            {
                dragonDeathObserver.Update(this.WeaponToDrop);
            }
        }
    }
}
