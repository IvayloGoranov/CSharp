using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FootballBetting.Models.Interfaces;

namespace FootballBetting.Models
{
    public abstract class BaseModel<TKey> : IModifiableEntity, IDeletableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Key]
        public virtual TKey Id { get; set; }
    }
}
