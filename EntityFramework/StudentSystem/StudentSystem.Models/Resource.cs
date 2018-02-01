using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string ResourceName { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Url]
        [Required]
        [MaxLength(100)]
        public string URL { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
