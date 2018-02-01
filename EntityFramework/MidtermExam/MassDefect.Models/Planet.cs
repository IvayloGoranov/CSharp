using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    public class Planet : SolarSystemObject
    {
        private ICollection<Person> persons;
        private ICollection<Anomaly> originPlanetAnomalies;
        private ICollection<Anomaly> teleportPlanetAnomalies;

        public Planet()
        {
            this.persons = new HashSet<Person>();
            this.originPlanetAnomalies = new HashSet<Anomaly>();
            this.teleportPlanetAnomalies = new HashSet<Anomaly>();
        }

        public virtual ICollection<Person> Persons
        {
            get
            {
                return this.persons;
            }

            set
            {
                this.persons = value;
            }
        }

        [InverseProperty("OriginPlanet")]
        public virtual ICollection<Anomaly> OriginPlanetAnomalies
        {
            get
            {
                return this.originPlanetAnomalies;
            }

            set
            {
                this.originPlanetAnomalies = value;
            }
        }

        [InverseProperty("TeleportPlanet")]
        public virtual ICollection<Anomaly> TeleportPlanetAnomalies
        {
            get
            {
                return this.teleportPlanetAnomalies;
            }

            set
            {
                this.teleportPlanetAnomalies = value;
            }
        }
    }
}
