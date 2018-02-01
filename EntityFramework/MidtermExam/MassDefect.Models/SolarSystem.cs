using System.Collections.Generic;

namespace MassDefect.Models
{
    public class SolarSystem : BaseEntityWithName<int>
    {
        private ICollection<Star> stars;
        private ICollection<Planet> planets;
        private ICollection<Sun> suns;

        public SolarSystem()
        {
            this.stars = new HashSet<Star>();
            this.planets = new HashSet<Planet>();
            this.suns = new HashSet<Sun>();
        }

        public virtual ICollection<Star> Stars
        {
            get
            {
                return this.stars;
            }

            set
            {
                this.stars = value;
            }
        }

        public virtual ICollection<Planet> Planets
        {
            get
            {
                return this.planets;
            }

            set
            {
                this.planets = value;
            }
        }

        public virtual ICollection<Sun> Suns
        {
            get
            {
                return this.suns;
            }

            set
            {
                this.suns = value;
            }
        }
    }
}
