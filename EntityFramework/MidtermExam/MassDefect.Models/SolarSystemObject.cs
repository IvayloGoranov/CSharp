using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    public abstract class SolarSystemObject : BaseEntityWithName<int>
    {
        [ForeignKey("SolarSystem")]
        public int SolarSystemId { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }
    }
}
