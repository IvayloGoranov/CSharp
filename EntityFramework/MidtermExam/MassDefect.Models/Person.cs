using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    public class Person : BaseEntityWithName<int>
    {
        private ICollection<Anomaly> anomalies;

        public Person()
        {
            this.anomalies = new HashSet<Anomaly>();
        }

        [ForeignKey("Planet")]
        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }

        public virtual ICollection<Anomaly> Anomalies
        {
            get
            {
                return this.anomalies;
            }

            set
            {
                this.anomalies = value;
            }
        }
    }
}
