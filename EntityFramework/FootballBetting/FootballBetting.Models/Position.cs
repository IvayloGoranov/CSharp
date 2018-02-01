using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class Position : BaseModel<string>
    {
        private ICollection<Player> players;

        public Position()
        {
            this.players = new HashSet<Player>();
        }

        [Key]
        public override string Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 2)
                {
                    throw new ArgumentException("Position id should be a 2-letter initial.");
                }

                base.Id = value;
            }
        }

        [MaxLength(100, ErrorMessage = "Position description should be no more than 100 letters long.")]
        public string Description { get; set; }

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
    }
}
