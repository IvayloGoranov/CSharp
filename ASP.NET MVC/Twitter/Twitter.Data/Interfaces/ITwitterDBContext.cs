using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

using Twitter.Models;

namespace Twitter.Data.Interfaces
{
    public interface ITwitterDBContext
    {
        IDbSet<Message> Messages { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<PostFavourite> PostFavourites { get; set; }

        IDbSet<Following> Followings { get; set; }

        IDbSet<UserImage> UserImages { get; set; }

        DbEntityEntry Entry(object entity);

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
