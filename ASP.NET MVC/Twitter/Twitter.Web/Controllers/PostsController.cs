using System.Linq;
using System.Web.Mvc;

using Twitter.Data.Interfaces;
using Twitter.Models;
using Twitter.Web.InputModels;

namespace Twitter.Web.Controllers
{
    [Authorize]
    public class PostsController : BaseController
    {
        public PostsController(ITwitterData data)
            : base(data)
        {
        }

        public PostsController(ITwitterData data, User userProfile)
            : base(data, userProfile)
        {
        }

        public ActionResult Like(int id)
        {
            var hasExistingLike =
                this.Data.PostFavourites.GetAll().
                Any(x => x.UserId == this.UserProfile.Id && x.PostId == id);
            if (!hasExistingLike)
            {
                var postFavoutite = new PostFavourite
                {
                    UserId = this.UserProfile.Id,
                    PostId = id
                };

                var post = this.Data.Posts.Find(id);

                var notification = new Notification
                {
                    UserId = post.UserID,
                    NotificationType = NotificationType.TweetFavoured,
                    Title = "Tweet favoured",
                    Content = string.Format("{0} favoured your tweet: {1}",
                            this.UserProfile.UserName, post.Content)
                };

                this.Data.Notifications.Add(notification);
                this.Data.PostFavourites.Add(postFavoutite);
                this.Data.SaveChanges();
            }

            int likesCount = this.Data.PostFavourites.GetAll().Where(x => x.PostId == id).Count();

            return this.Content(string.Format("<strong>Likes:</strong> {0}", likesCount));
        }

        [HttpGet]
        public ActionResult Tweet(int? id)
        {
            var postInputModel = new PostInputModel { QuestionID = id };

            return this.View(postInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tweet(PostInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var newPost = new Post { Title = model.Title, Content = model.Content,
                    PostURL = model.PostURL, UserID = this.UserProfile.Id, QuestionID = model.QuestionID };
                this.Data.Posts.Add(newPost);
                this.Data.SaveChanges();

                if (model.QuestionID != null)
                {
                    var newPostAnswer = new PostAnswer
                    {
                        ParentPostId = (int)model.QuestionID,
                        AnswerId = newPost.Id
                    };

                    this.Data.PostAnswers.Add(newPostAnswer);
                    this.Data.SaveChanges();
                }

                if (this.HttpContext.Cache["allPosts"] != null)
                {
                    this.HttpContext.Cache.Remove("allPosts");
                }

                if (this.HttpContext.Cache[this.UserProfile.Id + "-Posts"] != null)
                {
                    this.HttpContext.Cache.Remove(this.UserProfile.Id + "-Posts");
                }

                this.TempData["Message"] = "Tweet created";
                return this.RedirectToAction("Index", "Users", new { username = this.UserProfile.UserName });
            }

            return this.View(model);
        }

        public ActionResult Retweet(int id)
        {
            var post = this.Data.Posts.GetAll().
                FirstOrDefault(x => x.Id == id);
            var notification = new Notification
            {
                UserId = post.UserID,
                NotificationType = NotificationType.Retweet,
                Title = "Tweet retweeted",
                Content = string.Format("{0} retweeted your tweet: {1}", 
                            this.UserProfile.UserName, post.Content)
            };

            this.Data.Notifications.Add(notification);

            var newPost = new Post
            {
                Title = post.Title,
                Content = post.Content,
                PostURL = post.PostURL,
                UserID = this.UserProfile.Id,
                QuestionID = null,
                Retweeted = true
            };

            this.UserProfile.Posts.Add(newPost);

            this.Data.SaveChanges();

            return this.RedirectToAction("Index", "Users", new { username = this.UserProfile.UserName });
        }

        public ActionResult Answer(int id)
        {
            return this.RedirectToAction("Tweet", "Posts", new { id = id });
        }

        public ActionResult Delete(int id)
        {
            var post = this.Data.Posts.Find(id);
            post.IsDeleted = true;
            this.Data.SaveChanges();

            if (this.HttpContext.Cache["allPosts"] != null)
            {
                this.HttpContext.Cache.Remove("allPosts");
            }

            if (this.HttpContext.Cache[this.UserProfile.Id + "-Posts"] != null)
            {
                this.HttpContext.Cache.Remove(this.UserProfile.Id + "-Posts");
            }

            this.TempData["Message"] = "Tweet deleted";

            return this.RedirectToAction("Index", "Users", new { username = this.UserProfile.UserName });
        }
    }
}