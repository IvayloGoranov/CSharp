
using System.Collections.Generic;

namespace FootballBetting.Models
{
    public class CompetitionType : BaseEntityWithName<int>
    {
        private ICollection<Competition> competitions;

        public CompetitionType()
        {
            this.competitions = new HashSet<Competition>();
        }

        public virtual ICollection<Competition> Competitions
        {
            get
            {
                return this.competitions;
            }

            set
            {
                this.competitions = value;
            }
        }
    }
}
