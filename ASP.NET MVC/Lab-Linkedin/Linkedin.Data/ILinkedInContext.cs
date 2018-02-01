using System.Data.Entity;
namespace LinkedIn.Data
{
    using Models;
    using LinkedIn.Models;

    public interface ILinkedInContext
    {

        IDbSet<Certification> Certifications { get; set; }

        IDbSet<Discussion> Discussions { get; set; }

        IDbSet<Experience> Experiences { get; set; }

        IDbSet<Group> Groups { get; set; }

        IDbSet<UserLanguage> Languages { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Skill> Skills { get; set; }

        IDbSet<Endorcement> Endorcements { get; set; }

        IDbSet<AdministrationLog> AdministrationLogs { get; set; }

        int SaveChanges();
    }
}
