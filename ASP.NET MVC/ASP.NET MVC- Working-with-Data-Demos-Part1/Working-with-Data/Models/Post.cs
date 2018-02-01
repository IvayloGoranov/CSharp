using System;

namespace Scaffolding.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsFeatured { get; set; }

        public PostType Type { get; set; }
    }
}