namespace LinkedIn.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Experience
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string CompanyName { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Location { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? LeavingDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
