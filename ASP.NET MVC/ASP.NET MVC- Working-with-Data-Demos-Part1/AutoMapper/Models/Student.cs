using System;
using System.ComponentModel.DataAnnotations;
namespace DataValidation.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The FullName is required!", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The FullName length should be between {2} and {1}")]
        public string FullName { get; set; }

        [Range(2, 6, ErrorMessage = "The AverageGrade should be between {1} and {2}")]
        public decimal AverageGrade { get; set; }

        public DateTime RegistrationDate { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid faculty number!")]
        public string FacultyNumber { get; set; }
    }
}