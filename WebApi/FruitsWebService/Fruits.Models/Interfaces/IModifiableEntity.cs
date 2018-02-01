using System;

namespace Fruits.Models.Interfaces
{
    public interface IModifiableEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
