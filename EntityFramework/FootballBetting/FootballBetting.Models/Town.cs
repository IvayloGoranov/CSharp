using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBetting.Models
{
    public class Town : BaseEntityWithName<int>
    {
        private ICollection<Team> teams;

        public Town()
        {
            this.teams = new HashSet<Team>();
        }

        [ForeignKey("Country")]
        public string CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Team> Teams
        {
            get
            {
                return this.teams;
            }

            set
            {
                this.teams = value;
            }
        }
    }
}
