namespace Events.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Events.Data;

    using Microsoft.Ajax.Utilities;

    public class EventDetailsViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Event, EventDetailsViewModel>> ViewModel
        {
            get
            {
                return e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Description = e.Description,
                    Comments = e.Comments.AsQueryable().Select(CommentViewModel.ViewModel),
                    AuthorId = e.Author.Id
                };
            }
        }
    }
}
