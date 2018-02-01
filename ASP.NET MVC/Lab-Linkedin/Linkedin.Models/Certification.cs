namespace LinkedIn.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Certification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LicenseNumber { get; set; }

        public string Url { get; set; }

        public DateTime TakenDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
