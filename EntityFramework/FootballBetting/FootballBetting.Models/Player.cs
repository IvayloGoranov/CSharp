using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBetting.Models
{
    public class Player : BaseEntityWithName<int>
    {
        private ICollection<Position> positions;
        private ICollection<PlayerStatistics> statistics;

        public Player()
        {
            this.positions = new HashSet<Position>();
            this.statistics = new HashSet<PlayerStatistics>();
        }

        [Range(0, 1000, ErrorMessage = "Enter a value between 1 and 1000")]
        public int SquadNumber { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public bool IsInjured { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<Position> Positions
        {
            get
            {
                return this.positions;
            }

            set
            {
                this.positions = value;
            }
        }

        public virtual ICollection<PlayerStatistics> Statistics
        {
            get
            {
                return this.statistics;
            }

            set
            {
                this.statistics = value;
            }
        }
    }
}
