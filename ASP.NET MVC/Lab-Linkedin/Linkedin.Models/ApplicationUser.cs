using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Linkedin.Models
{
    public class ApplicationUser : IdentityUser
    {
        //private ICollection<Certification> certifications;
        //private ICollection<Project> projects;
        //private ICollection<Experience> experiences;
        //private ICollection<UserLanguage> userLanguages;
        //private ICollection<Group> groups;
        //private ICollection<Skill> skills;

        public ApplicationUser()
        {
            this.ContactInfo = new ContactInfo();
            this.Certifications = new HashSet<Certification>();
            this.Projects = new HashSet<Project>();
            this.Experiences = new HashSet<Experience>();
            this.UserLanguages = new HashSet<UserLanguage>();
            this.Groups = new HashSet<Group>();
            this.UserSkills = new HashSet<UserSkill>();
        }

        public ContactInfo ContactInfo { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public virtual ICollection<Certification> Certifications { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }

        public virtual ICollection<UserLanguage> UserLanguages { get; set; }

        [InverseProperty("Members")]
        public ICollection<Group> Groups { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in 
            //CookieAuthenticationOptions.AuthenticationType
            var userIdentity = 
                await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
