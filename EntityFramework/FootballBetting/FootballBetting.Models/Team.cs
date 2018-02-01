using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBetting.Models
{
    public class Team : BaseEntityWithName<int>
    {
        private ICollection<Player> players;
        private ICollection<Match> homeMatches;
        private ICollection<Match> awayMatches;

        public Team()
        {
            this.players = new HashSet<Player>();
            this.homeMatches = new HashSet<Match>();
            this.awayMatches = new HashSet<Match>();
        }

        [StringLength(3, ErrorMessage = "Team initial should be exactly e letters long.", MinimumLength = 3)]
        public string Initial { get; set; }

        [ForeignKey("PrimaryKitColor")]
        public int PrimaryKitColorId { get; set; }

        [ForeignKey("SecondaryKitColor")]
        public int SecondaryColorId { get; set; }

        [ForeignKey("Town")]
        public int TownId { get; set; }

        public virtual Color PrimaryKitColor { get; set; }

        public virtual Color SecondaryKitColor { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Player> Players
        {
            get
            {
                return this.players;
            }

            set
            {
                this.players = value;
            }
        }

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Match> HomeMatches
        {
            get
            {
                return this.homeMatches;
            }

            set
            {
                this.homeMatches = value;
            }
        }

        [InverseProperty("AwayTeam")]
        public virtual ICollection<Match> AwayMatches
        {
            get
            {
                return this.awayMatches;
            }

            set
            {
                this.awayMatches = value;
            }
        }
    }
}
