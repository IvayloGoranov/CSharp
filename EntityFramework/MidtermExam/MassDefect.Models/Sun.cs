using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    public class Sun : SolarSystemObject
    {
        [Key, ForeignKey("Planet")]
        public override int Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }

        public virtual Planet Planet { get; set; }
    }
}
