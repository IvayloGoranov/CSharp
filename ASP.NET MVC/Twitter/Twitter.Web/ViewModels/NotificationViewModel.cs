using System;
using System.Linq.Expressions;

using Twitter.Models;

namespace Twitter.Web.ViewModels
{
    public class NotificationViewModel
    {
        public static Expression<Func<Notification, NotificationViewModel>> ViewModel
        {
            get
            {
                return x => new NotificationViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedOn = (DateTime)x.CreatedOn
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}