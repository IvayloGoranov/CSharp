using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

using Twitter.Models;

namespace Twitter.Web.ViewModels
{
    public class PostViewModel
    {
        public static Expression<Func<Post, PostViewModel>> ViewModel
        {
            get
            {
                return x => new PostViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                    PostURL = x.PostURL,
                    FavouritesCount = x.PostFavourites.AsQueryable().Count(f => !f.IsDeleted),
                    PostedBy = x.PostedBy.UserName,
                    Answers = x.Answers.AsQueryable().Select(AnswerViewModel.SelectViewModel),
                    QuestionTitle = x.Question.Title,
                    QuestionPostedBy = x.Question.PostedBy.UserName,
                    Retweeted = x.Retweeted
                };
            }
        }

        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        public string PostedBy { get; set; }

        public string PostURL { get; set; }

        public IEnumerable<AnswerViewModel> Answers { get; set; }

        [Display(Name = "Likes")]
        public int FavouritesCount { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string QuestionTitle { get; set; }

        public string QuestionPostedBy { get; set; }

        public bool? Retweeted { get; set; }
    }
}