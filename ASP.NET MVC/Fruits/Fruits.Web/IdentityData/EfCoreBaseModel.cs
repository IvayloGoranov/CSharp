using System;
using System.ComponentModel.DataAnnotations;

using Fruits.Models.Interfaces;

namespace Fruits.Web.IdentityData
{
    public abstract class EfCoreBaseModel<TKey> : IModifiableEntity, IDeletableEntity
    {
        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        [Key]
        public TKey Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
