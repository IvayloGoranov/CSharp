using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Twitter.Models.Interfaces;

namespace Twitter.Models
{
    public abstract class TitleAndContentEntity : BaseModel<int>, ITitleAndContentEntity
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characters long.", MinimumLength = 2)]
        [Index]
        public string Title { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Content { get; set; }
    }
}
