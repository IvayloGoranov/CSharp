using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string StudentName { get; set; }

        [MaxLength(40)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? Birthdate { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }

            set
            {
                this.homeworks = value;
            }
        }
    }
}
