using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models
{
    public abstract class BaseEntityWithName<TKey> : BaseModel<TKey>
    {
        [Required]
        [MaxLength(300, ErrorMessage = "Name should be no more than 300 letters long.")]
        [Index]
        public virtual string Name { get; set; }
    }
}
