
using System.Collections.Generic;

namespace FootballBetting.Models
{
    public class ResultPrediction : BaseModel<int>
    {
        private ICollection<MatchBet> matchBets;

        public ResultPrediction()
        {
            this.matchBets = new HashSet<MatchBet>();
        }

        public ResultPredictionType ResultPredictionType { get; set; }

        public virtual ICollection<MatchBet> MatchBets
        {
            get
            {
                return this.matchBets;
            }

            set
            {
                this.matchBets = value;
            }
        }
    }
}
