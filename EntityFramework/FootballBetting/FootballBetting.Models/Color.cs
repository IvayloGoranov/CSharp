using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBetting.Models
{
    public class Color : BaseEntityWithName<int>
    {
        private ICollection<Team> teamsPrimaryKitColors;
        private ICollection<Team> teamsSecondaryKitColors;

        public Color()
        {
            this.teamsPrimaryKitColors = new HashSet<Team>();
            this.teamsSecondaryKitColors = new HashSet<Team>();
        }

        [InverseProperty("PrimaryKitColor")]
        public virtual ICollection<Team> TeamsPrimaryKitColors
        {
            get
            {
                return this.teamsPrimaryKitColors;
            }

            set
            {
                this.teamsPrimaryKitColors = value;
            }
        }

        [InverseProperty("SecondaryKitColor")]
        public virtual ICollection<Team> TeamsSecondaryKitColors
        {
            get
            {
                return this.teamsSecondaryKitColors;
            }

            set
            {
                this.teamsSecondaryKitColors= value;
            }
        }
    }
}
