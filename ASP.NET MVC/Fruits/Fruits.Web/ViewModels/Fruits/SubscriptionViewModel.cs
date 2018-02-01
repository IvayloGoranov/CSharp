using System;
using System.Linq.Expressions;

using Fruits.Web.IdentityData;

namespace Fruits.Web.ViewModels.Fruits
{
    public class SubscriptionViewModel
    {
        public static Expression<Func<Subscription, SubscriptionViewModel>> MapToDTO
        {
            get
            {
                return x => new SubscriptionViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Checked { get; set; }
    }
}
