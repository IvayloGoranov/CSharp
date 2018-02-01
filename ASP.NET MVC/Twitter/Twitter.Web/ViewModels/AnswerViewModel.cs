using System;
using System.Linq;
using System.Linq.Expressions;

using Twitter.Models;

namespace Twitter.Web.ViewModels
{
    public class AnswerViewModel : PostViewModel
    {
        public static Expression<Func<PostAnswer, AnswerViewModel>> SelectViewModel
        {
            get
            {
                return x => new AnswerViewModel
                {
                    Id = x.Id,
                    Title = x.Answer.Title,
                    Content = x.Answer.Content,
                    CreatedOn = x.CreatedOn,
                    PostURL = x.Answer.PostURL,
                    FavouritesCount = x.Answer.PostFavourites.AsQueryable().Count(),
                    PostedBy = x.Answer.PostedBy.UserName,
                    QuestionTitle = x.Post.Title,
                    QuestionPostedBy = x.Post.PostedBy.UserName
                };
            }
        }
    }
}