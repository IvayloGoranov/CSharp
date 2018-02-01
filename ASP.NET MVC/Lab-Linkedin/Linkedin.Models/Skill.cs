namespace LinkedIn.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        private ICollection<UserSkill> users;

        public Skill()
        {
            this.users = new HashSet<UserSkill>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserSkill> UserSkills
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
