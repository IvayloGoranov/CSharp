using System;

namespace ProductsAndCategories.Data.Interfaces
{
    public interface IEntityBase
    {
        int ID { get; }
        bool IsDeleted { get; set; }
    }
}
