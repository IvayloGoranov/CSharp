using System.Data.Entity;

using Linkedin.Models;

namespace Linkedin.Data
{
    public interface ILinkedInDbContext
    {
        IDbSet<Certification> Certifications { get; set; }

        IDbSet<Discussion> Discussions { get; set; }

        IDbSet<Experience> Experiences { get; set; }

        IDbSet<Group> Groups { get; set; }

        IDbSet<UserLanguage> UserLanguages { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Skill> Skill { get; set; }

        IDbSet<Endorsement> Endorsements { get; set; }

        IDbSet<AdministrationLog> AdministrationLogs { get; set; }

        int SaveChanges();
    }
}
