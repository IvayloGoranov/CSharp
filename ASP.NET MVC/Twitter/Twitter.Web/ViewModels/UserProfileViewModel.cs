using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

using Twitter.Models;

namespace Twitter.Web.ViewModels
{
    public class UserProfileViewModel
    {
        public static Expression<Func<User, UserProfileViewModel>> ViewModel
        {
            get
            {
                return x => new UserProfileViewModel
                {
                    UserId = x.Id,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Summary = x.Summary,
                    CreatedOn = x.CreatedOn,
                    Followers = x.Followers.AsQueryable().Where(f => f.IsDeleted == false).
                                        Select(f => f.Follower.UserName),
                    Followings = x.Followings.AsQueryable().Where(f => f.IsDeleted == false).Count(),
                    Posts = x.Posts.AsQueryable().Count(f => f.IsDeleted == false),
                    Likes = x.PostFavourites.AsQueryable().Count(f => f.IsDeleted == false)
                };
            }
        }

        public string UserId { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        public string Summary { get; set; }

        [Display(Name = "Member since")]
        public DateTime? CreatedOn { get; set; }

        public int Likes { get; set; }

        public IEnumerable<string> Followers { get; set; }

        public int Followings { get; set; }

        public int Posts { get; set; }

        public int Answers { get; set; }
    }
}