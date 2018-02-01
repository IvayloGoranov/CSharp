namespace LinkedIn.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using LinkedIn.Models;

    public class UserSkill
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        public virtual ICollection<Endorcement> Endorcements { get; set; }
    }
}
