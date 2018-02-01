using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string LicenseName { get; set; }

        [ForeignKey("Resource")]
        public int ResourceId { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
