using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FootballBetting.Models
{
    public class MatchBet
    {
        [Key, ForeignKey("Match"), Column(Order = 0)]
        public int MatchId { get; set; }

        [Key, ForeignKey("Bet"), Column(Order = 1)]
        public int BetId { get; set; }

        [ForeignKey("ResultPrediction")]
        public int ResultPredictionId { get; set; }

        public virtual ResultPrediction ResultPrediction { get; set; }

        public virtual Match Match { get; set; }

        public virtual Bet Bet { get; set; }
    }
}
