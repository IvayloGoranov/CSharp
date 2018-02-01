using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class Post : TitleAndContentEntity
    {
        private ICollection<PostFavourite> postFavourites;
        private ICollection<PostAnswer> answers;
        private ICollection<Post> childPosts;

        public Post()
        {
            this.postFavourites = new HashSet<PostFavourite>();
            this.answers = new HashSet<PostAnswer>();    
        }

        [Url]
        [MaxLength(100, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string PostURL { get; set; }

        [ForeignKey("PostedBy")]
        [Required]
        public string UserID { get; set; }

        public int? QuestionID { get; set; }

        public bool? Retweeted { get; set; }

        public virtual Post Question { get; set; }

        public virtual User PostedBy { get; set; }

        public virtual ICollection<Post> ChildPosts
        {
            get
            {
                return this.childPosts;
            }

            set
            {
                this.childPosts = value;
            }
        }

        public virtual ICollection<PostAnswer> Answers
        {
            get
            {
                return this.answers;
            }

            set
            {
                this.answers = value;
            }
        }

        public virtual ICollection<PostFavourite> PostFavourites
        {
            get
            {
                return this.postFavourites;
            }

            set
            {
                this.postFavourites = value;
            }
        }
    }
}
