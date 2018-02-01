using System.Data.Entity;

using OnlineShop.Models;

namespace OnlineShop.Data
{
    public interface IOnlineShopContext
    {
        IDbSet<Ad> Ads { get; set; }

        IDbSet<AdType> AdTypes { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();
    }
}
