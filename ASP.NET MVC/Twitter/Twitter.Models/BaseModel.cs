using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Twitter.Models.Interfaces;

namespace Twitter.Models
{
    public abstract class BaseModel<TKey> : IModifiableEntity, IDeletableEntity
    {
        [Key]
        public TKey Id { get; set; }

        [Index]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
