using System.Linq;
using System.Web.Mvc;

using PagedList;

using Twitter.Data.Interfaces;
using Twitter.Models;
using Twitter.Web.ViewModels;

namespace Twitter.Web.Controllers
{
    [Authorize]
    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }

        public NotificationsController(ITwitterData data, User userProfile)
            : base(data, userProfile)
        {
        }

        public ActionResult Index(int? page)
        {
            var allNotificationsQuery = this.Data.Notifications.GetAll().
                Where(x => x.UserId == this.UserProfile.Id).
                Select(NotificationViewModel.ViewModel).
                OrderByDescending(x => x.CreatedOn);

            int pageSize = 5;
            int pageNumber = 1;
            if (page != null)
            {
                pageNumber = (int)page;
            }

            return this.View(allNotificationsQuery.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Delete(int id)
        {
            var notification = this.Data.Notifications.Find(id);
            notification.IsDeleted = true;
            this.Data.SaveChanges();

            this.ViewBag.NotificationDeleted = "Notification deleted";

            return this.RedirectToAction("Index");
        }
    }
}