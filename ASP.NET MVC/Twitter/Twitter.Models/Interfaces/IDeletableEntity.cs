using System;

namespace Twitter.Models.Interfaces
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
