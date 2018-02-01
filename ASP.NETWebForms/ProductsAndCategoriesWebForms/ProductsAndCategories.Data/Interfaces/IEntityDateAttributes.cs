using System;

namespace ProductsAndCategories.Data.Interfaces
{
    public interface IEntityDateAttributes
    {
        DateTime CreatedDate { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
    }
}
