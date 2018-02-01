using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBetting.Models
{
    public class Bet : BaseModel<int>
    {
        private ICollection<MatchBet> matchBets;

        public Bet()
        {
            this.matchBets = new HashSet<MatchBet>();
        }

        [Range(0, 9999999999999999.99, ErrorMessage = "Please enter a positive amount.")]
        public decimal Amount { get; set; }

        public DateTime BetDateTime { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

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
