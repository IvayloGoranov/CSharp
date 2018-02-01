using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public abstract class BaseEntityWithName<TKey> : BaseModel<TKey>
    {
        [Required]
        [MaxLength(300, ErrorMessage = "Name should be no more than 300 letters long.")]
        public virtual string Name { get; set; }
    }
}
