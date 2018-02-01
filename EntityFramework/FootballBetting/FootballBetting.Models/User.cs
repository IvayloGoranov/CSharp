using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using FootballBetting.Models.Attributes;

namespace FootballBetting.Models
{
    public class User : BaseModel<string>
    {
        private ICollection<Bet> bets;

        public User()
        {
            this.bets = new HashSet<Bet>();
        }

        [Required]
        [MaxLength(50, ErrorMessage = "Username should be no more than 50 letters long.")]
        public string Username { get; set; }

        [Required]
        [Password(4, 20, ShouldContainLowercase = true, ShouldContainUppercase = true, 
            ShouldContainSpecialSymbol = true, ShouldContainDigit = false)]
        public string Password { get; set; }

        [Email]
        public string Email { get; set; }

        [Range(0, 9999999999999999.99, ErrorMessage = "Please enter a positive amount.")]
        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets
        {
            get
            {
                return this.bets;
            }

            set
            {
                this.bets = value;
            }
        }
    }
}
