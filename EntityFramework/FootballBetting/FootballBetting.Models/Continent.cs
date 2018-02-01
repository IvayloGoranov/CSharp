using System;
using System.Collections.Generic;

namespace FootballBetting.Models
{
    public class Continent : BaseEntityWithName<int>
    {
        private ICollection<Country> countries;

        public Continent()
        {
            this.countries = new HashSet<Country>();
        }

        public override string Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                bool isValidContinent = (value != "Europe") || (value != "Africa") || (value != "Asia")
                    || (value != "North America") || (value != "South America") || (value != "Australia")
                    || (value != "Oceania");
                if (!isValidContinent)
                {
                    throw new ArgumentException("Invalid continent");
                }

                base.Name = value;
            }
        }

        public virtual ICollection<Country> Countries
        {
            get
            {
                return this.countries;
            }

            set
            {
                this.countries = value;
            }
        }
    }
}
