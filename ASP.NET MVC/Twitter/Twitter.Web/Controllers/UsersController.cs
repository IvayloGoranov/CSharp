using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System;
using System.Web.Caching;
using System.Collections.Generic;

using PagedList;

using Twitter.Data.Interfaces;
using Twitter.Models;
using Twitter.Web.ViewModels;
using Twitter.Web.InputModels;
using Twitter.Web.CustomAttributes;

namespace Twitter.Web.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(ITwitterData data)
            : base(data)
        {
        }

        public UsersController(ITwitterData data, User userProfile)
            : base(data, userProfile)
        {
        }

        public ActionResult Index(string username)
        {
            var userProfile = this.Data.Users.GetAll()
                .Include(x => x.Followers)
                .Include(x => x.Followings)
                .Include(x => x.Posts)
                .Include(x => x.Posts.Select(p => p.Answers))
                .Include(x => x.Posts.Select(p => p.PostFavourites))
                .Select(UserProfileViewModel.ViewModel)
                .Where(x => x.UserName == username)
                .FirstOrDefault();

            var userAnswers = this.Data.Users.GetAll()
                .Include(x => x.Posts.Select(p => p.Answers))
                .Where(x => x.Id == userProfile.UserId)
                .Select(x => x.Posts.AsQueryable().
                            Select(p => p.Answers.AsQueryable().
                                    Select(AnswerViewModel.SelectViewModel))).AsQueryable().Count();

            userProfile.Answers = userAnswers;

            return View(userProfile);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var editInputModel = EditUserInputModel.FromModel(this.UserProfile);

            return this.View(editInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var updatedUser = model.UpdateUser(this.UserProfile);
                this.Data.Users.Update(updatedUser);
                this.Data.SaveChanges();

                this.TempData["Message"] = "Profile updated";
                return this.RedirectToAction("Index", "Users", new { username = this.UserProfile.UserName });
            }

            return this.View(model);
        }

        public ActionResult Follow(string id)
        {
            var userToFollow = this.Data.Users.GetAll().
                FirstOrDefault(x => x.Id == id);

            var following = new Following { UserId = id, FollowerId = this.UserProfile.Id };
            var existingFollowing = this.Data.Followings.GetAll().
                Where(x => x.UserId == id && x.FollowerId == this.UserProfile.Id).
                FirstOrDefault();
            if (existingFollowing != null)
            {
                existingFollowing.IsDeleted = false;
            }
            else
            {
                this.Data.Followings.Add(following);

                var notification = new Notification
                {
                    UserId = id,
                    NotificationType = NotificationType.NewFollower,
                    Title = "New follower",
                    Content = string.Format("User {0} is now following you.",
                            this.UserProfile.UserName)
                };

                this.Data.Notifications.Add(notification);
            }

            this.Data.SaveChanges();

            return this.RedirectToAction("Index", "Users", new { username = userToFollow.UserName });
        }

        public ActionResult Unfollow(string id)
        {
            var userToUnfollow = this.Data.Users.GetAll().
                FirstOrDefault(x => x.Id == id);

            var following = this.Data.Followings.GetAll().
                Where(x => x.UserId == id && x.FollowerId == this.UserProfile.Id).
                FirstOrDefault();
            following.IsDeleted = true;
            this.Data.SaveChanges();

            return this.RedirectToAction("Index", "Users", new { username = userToUnfollow.UserName });
        }

        [AjaxChildActionOnly]
        public ActionResult Tweets(int? page, string id)
        {
            int pageSize = 3;
            int pageNumber = 1;
            if (page != null)
            {
                pageNumber = (int)page;
            }

            if (this.HttpContext.Cache[id + "-Posts"] == null)
            {
                var userTweets = this.Data.Posts.GetAll().
                    Include(x => x.PostFavourites).
                    Include(x => x.Answers).
                    Where(x => x.Question == null && x.PostedBy.Id == id).
                    Select(PostViewModel.ViewModel).
                    OrderByDescending(x => x.CreatedOn).ToList();

                this.HttpContext.Cache.Insert(
                    id + "-Posts",                    // key
                    userTweets,                       // value
                    null,                             // dependencies
                    DateTime.Now.AddSeconds(10),     // absolute exp.
                    TimeSpan.Zero,                    // sliding exp.
                    CacheItemPriority.Default,        // priority
                    null);                            // callback delegate
            }

            this.ViewBag.UserId = id;

            var userTweetsPagedList =
                ((List<PostViewModel>)this.HttpContext.Cache[id + "-Posts"]).
                                ToPagedList(pageNumber, pageSize);

            return this.View(userTweetsPagedList);
        }

        [AjaxChildActionOnly]
        public ActionResult Following(int? page, string id)
        {
            var userFollowings = this.Data.Followings.GetAll().
                Where(x => x.FollowerId == id).
                Select(x => x.User.UserName).
                OrderBy(x => x);

            this.ViewBag.UserId = id;

            int pageSize = 7;
            int pageNumber = 1;
            if (page != null)
            {
                pageNumber = (int)page;
            }

            return this.View(userFollowings.ToPagedList(pageNumber, pageSize));
        }

        [OutputCache(Duration = 30, VaryByParam = "id")]
        [AjaxChildActionOnly]
        public PartialViewResult Followers(int? page, string id)
        {
            var userFollowers = this.Data.Followings.GetAll().
                Where(x => x.UserId == id).
                Select(x => x.Follower.UserName).
                OrderBy(x => x);

            this.ViewBag.UserId = id;

            int pageSize = 7;
            int pageNumber = 1;
            if (page != null)
            {
                pageNumber = (int)page;
            }

            return this.PartialView(userFollowers.ToPagedList(pageNumber, pageSize));
        }

        [AjaxChildActionOnly]
        public ActionResult Likes(int? page, string id)
        {
            var userLikes = this.Data.PostFavourites.GetAll().
                Where(x => x.UserId == id).
                Select(x => x.Post).
                Select(PostViewModel.ViewModel).
                OrderByDescending(x => x.CreatedOn);

            this.ViewBag.UserId = id;

            int pageSize = 3;
            int pageNumber = 1;
            if (page != null)
            {
                pageNumber = (int)page;
            }

            return this.View(userLikes.ToPagedList(pageNumber, pageSize));
        }

        [AjaxChildActionOnly]
        public ActionResult Answers(int? page, string id)
        {
            var userAnswers = this.Data.PostAnswers.GetAll().
                Where(x => x.Answer.UserID == id).
                Select(x => x.Answer).
                Select(PostViewModel.ViewModel).
                OrderByDescending(x => x.CreatedOn);

            this.ViewBag.UserId = id;

            int pageSize = 3;
            int pageNumber = 1;
            if (page != null)
            {
                pageNumber = (int)page;
            }

            return this.View(userAnswers.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ShowImage(string id)
        {
            //this.HttpContext.Response.Cache.SetCacheability(HttpCacheability.Public);
            //this.HttpContext.Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));

            var image = this.Data.UserImages.Find(id);
            var imageData = image.Avatar;
            DateTime imageLastModifiedTime = 
                image.ModifiedOn != null ? (DateTime)image.ModifiedOn : (DateTime)image.CreatedOn;

            string headerIfModifiedSinceText = HttpContext.Request.Headers.Get("If-Modified-Since");
            if (string.IsNullOrEmpty(headerIfModifiedSinceText))
            {
                this.HttpContext.Response.Cache.SetLastModified(imageLastModifiedTime);
            }
            else
            {
                DateTime headerIfModifiedSince = DateTime.Parse(headerIfModifiedSinceText);

                // HTTP does not provide milliseconds, so remove it from the comparison
                if (imageLastModifiedTime.AddMilliseconds(
                         -imageLastModifiedTime.Millisecond) == headerIfModifiedSince)
                {
                    // The requested file has not changed
                    this.HttpContext.Response.StatusCode = 304;
                    return Content(string.Empty);
                }
            }

            return this.File(imageData, "image/jpg");
        }

        [ValidateAntiForgeryToken]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                //string pic = Path.GetFileName(file.FileName);
                //string path = Path.Combine(Server.MapPath("~/images/profile"), pic);
                //// file is uploaded
                //file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();

                    var userImage = new UserImage { UserId = this.UserProfile.Id, Avatar = array };
                    var existingImage = this.Data.UserImages.GetAll().
                        FirstOrDefault(x => x.UserId == this.UserProfile.Id);
                    if (existingImage != null)
                    {
                        existingImage.Avatar = array;
                    }
                    else
                    {
                        this.Data.UserImages.Add(userImage);
                    }

                    this.Data.SaveChanges();
                }
            }

            this.TempData["Message"] = "Profile updated";

            // after successfully uploading redirect the user
            return this.RedirectToAction("Index", new { username = this.UserProfile.UserName });
        }
    }
}