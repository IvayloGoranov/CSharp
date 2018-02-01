
using Twitter.Models;

namespace Twitter.Data.Interfaces
{
    public interface ITwitterData
    {
        ITwitterDBContext TwitterDbContext { get; }

        IRepository<Message> Messages { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Post> Posts { get; }

        IRepository<PostFavourite> PostFavourites { get; }

        IRepository<PostAnswer> PostAnswers { get; }

        IRepository<User> Users { get; }

        IRepository<Following> Followings { get; }

        IRepository<UserImage> UserImages { get; }

        int SaveChanges();
    }
}
