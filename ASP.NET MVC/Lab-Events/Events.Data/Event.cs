namespace Events.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        public Event()
        {
            this.Comments = new HashSet<Comment>();
            this.IsPublic = true;
            this.StartDateTime = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string Description { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
