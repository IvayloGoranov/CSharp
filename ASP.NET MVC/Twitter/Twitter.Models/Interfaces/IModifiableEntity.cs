using System;

namespace Twitter.Models.Interfaces
{
    public interface IModifiableEntity
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
