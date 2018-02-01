
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fruits.Web.IdentityData
{
    public class UserSubscription
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
    }
}
