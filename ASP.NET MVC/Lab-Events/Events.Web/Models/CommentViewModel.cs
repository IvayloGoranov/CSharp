namespace Events.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Events.Data;

    public class CommentViewModel
    {
        public string Text { get; set; }

        public string Author { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> ViewModel
        {
            get
            {
                return c => new CommentViewModel()
                {
                    Text = c.Text,
                    Author = c.Author.FullName
                };
            }
        }
    }
}
