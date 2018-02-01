using System.Linq;

using BookShopSystem.Data;

namespace BookShopSystem.ConsoleClient
{
    public class BookShopSystemMain
    {
        public static void Main()
        {
            var context = new BookShopContext();

            int bookCount = context.Books.Count();
        }
    }
}
