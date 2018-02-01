namespace LinkedIn.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using LinkedIn.Models;

    public class Endorcement
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int UserSkillId { get; set; }

        public virtual UserSkill UserSkill { get; set; }
    }
}
