using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fruits.Web.IdentityData
{
    public class Subscription : EfCoreBaseModel<int>
    {
        public Subscription()
        {
            this.Users = new List<UserSubscription>();
        }

        [Required]
        [StringLength(20, ErrorMessage = "Fruit name should be between {1} and {2} characters long.",
           MinimumLength = 3)]
        public string Name { get; set; }

        public List<UserSubscription> Users { get; set; }
    }
}
