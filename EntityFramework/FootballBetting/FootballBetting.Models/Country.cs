using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class Country : BaseEntityWithName<string>
    {
        private ICollection<Town> towns;
        private ICollection<Continent> continents;

        public Country()
        {
            this.towns = new HashSet<Town>();
            this.continents = new HashSet<Continent>();
        }

        [Key]
        public override string Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 3)
                {
                    throw new ArgumentException("Country id should be a 3-letter initial.");
                }

                base.Id = value;
            }
        }

        public virtual ICollection<Continent> Continents
        {
            get
            {
                return this.continents;
            }

            set
            {
                this.continents = value;
            }
        }

        public virtual ICollection<Town> Towns
        {
            get
            {
                return this.towns;
            }

            set
            {
                this.towns = value;
            }
        }
    }
}
