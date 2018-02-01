using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Fruits.Models.Interfaces;

namespace Fruits.Models
{
    public abstract class BaseModel<TKey> : IModifiableEntity, IDeletableEntity
    {
        public DateTime? ModifiedOn { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        [Key]
        public virtual TKey Id { get; set; }

        [Index]
        public virtual bool IsDeleted { get; set; }

        public virtual DateTime? DeletedOn { get; set; }
    }
}
