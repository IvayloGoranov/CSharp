using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBetting.Models
{
    public class Match : BaseModel<int>
    {
        private ICollection<PlayerStatistics> statistics;
        private ICollection<MatchBet> matchBets;

        public Match()
        {
            this.statistics = new HashSet<PlayerStatistics>();
            this.matchBets = new HashSet<MatchBet>();
        }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }

        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }

        [ForeignKey("Round")]
        public int RoundId { get; set; }

        [ForeignKey("Competition")]
        public int CompetitionId { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Enter a value between 0 and 100")]
        public int HomeTeamGoals { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Enter a value between 0 and 100")]
        public int AwayTeamGoals { get; set; }

        [Required]
        public DateTime PlayedOn { get; set; }

        [Required]
        [Range(0.0d, 1000.0d, ErrorMessage = "Enter a value between 0 and 1000")]
        public double HomeTeamWinBetRate { get; set; }

        [Required]
        [Range(0.0d, 1000.0d, ErrorMessage = "Enter a value between 0 and 1000")]
        public double AwayTeamWinBetRate { get; set; }

        [Required]
        [Range(0.0d, 1000.0d, ErrorMessage = "Enter a value between 0 and 1000")]
        public double DrawBetRate { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual Round Round { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team AwayTeam { get; set; }

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
