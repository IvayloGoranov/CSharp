using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Twitter.Models.Interfaces;

namespace Twitter.Models
{
    public class UserImage : IDeletableEntity, IModifiableEntity
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public byte[] Avatar { get; set; }

        public virtual User User { get; set; }

        [Index]
        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
