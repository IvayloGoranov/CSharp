using System.Data.Entity;

using BookShopSystem.Models;

namespace BookShopSystem.Data.Interfaces
{
    public interface IBookShopContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<Category> Categories { get; set; }

        int SaveChanges();
    }
}
