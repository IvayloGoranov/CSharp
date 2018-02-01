using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookShopSystem.Models
{
    public class User : IdentityUser
    {
        private ICollection<Purchase> purchases;

        public User()
        {
            this.purchases = new HashSet<Purchase>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager,
            string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Purchase> Purchases
        {
            get
            {
                return this.purchases;
            }

            set
            {
                this.purchases = value;
            }
        }
    }
}
