using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

using OnlineShop.Models;
using OnlineShop.Data.Migrations;

namespace OnlineShop.Data
{
    public class OnlineShopContext : IdentityDbContext<ApplicationUser>, IOnlineShopContext
    {
        public OnlineShopContext()
            : base("name=OnlineShopContext")
        {
            Database.SetInitializer(new OnlineShopInitializer());
        }

        public IDbSet<Ad> Ads { get; set; }

        public IDbSet<AdType> AdTypes { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }
    }
}