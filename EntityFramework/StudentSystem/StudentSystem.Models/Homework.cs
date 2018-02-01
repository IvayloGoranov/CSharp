using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HomeworkContent { get; set; }

        [Required]
        public HomeworkContentType HomeworkContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
