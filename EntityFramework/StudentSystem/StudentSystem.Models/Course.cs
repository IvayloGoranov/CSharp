using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Resource> resources;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.resources = new HashSet<Resource>();
            this.homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string CourseName { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        public virtual ICollection<Resource> Resources
        {
            get
            {
                return this.resources;
            }

            set
            {
                this.resources = value;
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
