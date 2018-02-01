using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Fruits.Web.IdentityData
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        public User()
        {
            this.Subscriptions = new List<UserSubscription>();
        }

        [Required]
        public string Country { get; set; }

        public List<UserSubscription> Subscriptions { get; set; }
    }
}
