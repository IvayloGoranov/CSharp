using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    public class Anomaly : BaseModel<int>
    {
        private ICollection<Person> persons;

        public Anomaly()
        {
            this.persons = new HashSet<Person>();
        }

        [ForeignKey("OriginPlanet")]
        public int OriginPlanetId { get; set; }

        [ForeignKey("TeleportPlanet")]
        public int TeleportPlanetId { get; set; }

        public virtual Planet OriginPlanet { get; set; }

        public virtual Planet TeleportPlanet { get; set; }

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
    }
}
