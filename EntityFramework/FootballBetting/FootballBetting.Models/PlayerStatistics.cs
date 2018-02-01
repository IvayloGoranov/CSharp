using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBetting.Models
{
    public class PlayerStatistics
    {
        [Key, Column(Order = 0), ForeignKey("Player")]
        public int PlayerId { get; set; }

        [Key, Column(Order = 1), ForeignKey("Match")]
        public int MatchId { get; set; }

        [Range(0, 100, ErrorMessage = "Enter a value between 1 and 100")]
        public int Goals { get; set; }

        [Range(0, 1000, ErrorMessage = "Enter a value between 1 and 1000")]
        public int Assists { get; set; }

        [Range(0, 200, ErrorMessage = "Enter a value between 1 and 200")]
        public int MinutesPlayed { get; set; }

        public virtual Player Player { get; set; }

        public virtual Match Match { get; set; }


    }
}
