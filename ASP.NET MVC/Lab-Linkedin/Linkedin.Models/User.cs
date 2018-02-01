namespace LinkedIn.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Models;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Certification> certifications;
        private ICollection<Project> projects;
        private ICollection<Experience> experiences;
        private ICollection<UserLanguage> userLanguages;
        private ICollection<Group> groups;
        private ICollection<UserSkill> skills;

        public ApplicationUser()
        {
            this.ContactInfo = new ContactInfo();
            this.certifications = new HashSet<Certification>();
            this.projects = new HashSet<Project>();
            this.experiences = new HashSet<Experience>();
            this.userLanguages = new HashSet<UserLanguage>();
            this.groups = new HashSet<Group>();
            this.skills = new HashSet<UserSkill>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public virtual ICollection<Certification> Certifications
        {
            get { return this.certifications; }
            set { this.certifications = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public virtual ICollection<Experience> Experiences
        {
            get { return this.experiences; }
            set { this.experiences = value; }
        }

        public virtual ICollection<UserLanguage> Languages
        {
            get { return this.userLanguages; }
            set { this.userLanguages = value; }
        }

        [InverseProperty("Members")]
        public virtual ICollection<Group> Groups
        {
            get { return this.groups; }
            set { this.groups = value; }
        }

        public virtual ICollection<UserSkill> Skills
        {
            get { return this.skills; }
            set { this.skills = value; }
        }
    }
}
