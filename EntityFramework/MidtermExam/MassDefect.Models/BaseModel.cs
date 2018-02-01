using System.ComponentModel.DataAnnotations;

namespace MassDefect.Models
{
    public abstract class BaseModel<TKey>
    {
        [Key]
        public virtual TKey Id { get; set; }
    }
}
