
namespace FootballBetting.Models
{
    public class Competition : BaseEntityWithName<int>
    {
        public int CompetitionTypeId { get; set; }

        public virtual CompetitionType CompetitionType { get; set; }
    }
}
