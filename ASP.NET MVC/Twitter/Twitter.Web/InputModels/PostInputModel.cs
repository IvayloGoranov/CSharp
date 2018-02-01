using System.ComponentModel.DataAnnotations;

namespace Twitter.Web.InputModels
{
    public class PostInputModel
    {
        [Url]
        [MaxLength(100, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string PostURL { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be between {1} and {2} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Content { get; set; }

        public int? QuestionID { get; set; }
    }
}