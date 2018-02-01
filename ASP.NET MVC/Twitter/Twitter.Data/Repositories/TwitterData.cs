using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Twitter.Data.Interfaces;
using Twitter.Models;

namespace Twitter.Data.Repositories
{
    public class TwitterData : ITwitterData
    {
        private IDictionary<Type, object> repositories;

        public TwitterData(ITwitterDBContext dbContext)
        {
            this.TwitterDbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public ITwitterDBContext TwitterDbContext { get; private set; }

        public IRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public IRepository<Notification> Notifications
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        public IRepository<PostFavourite> PostFavourites
        {
            get
            {
                return this.GetRepository<PostFavourite>();
            }
        }

        public IRepository<PostAnswer> PostAnswers
        {
            get
            {
                return this.GetRepository<PostAnswer>();
            }
        }

        public IRepository<Post> Posts
        {
            get
            {
                return this.GetRepository<Post>();
            }
        }

        public IRepository<Following> Followings
        {
            get
            {
                return this.GetRepository<Following>();
            }
        }

        public IRepository<UserImage> UserImages
        {
            get
            {
                if (!this.repositories.ContainsKey(typeof(UserImage)))
                {
                    var typeOfUserImagesRepository = typeof(UserImagesRepository);
                    var repository = Activator.CreateInstance(typeOfUserImagesRepository,
                                                    this.TwitterDbContext);
                    this.repositories.Add(typeof(UserImage), repository);
                }

                return (IRepository<UserImage>)this.repositories[typeof(UserImage)];
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (!this.repositories.ContainsKey(typeof(User)))
                {
                    var typeOfUsersRepository = typeof(UsersRepository);
                    var repository = Activator.CreateInstance(typeOfUsersRepository, 
                                                    this.TwitterDbContext);
                    this.repositories.Add(typeof(User), repository);
                }

                return (IRepository<User>)this.repositories[typeof(User)];
            }
        }

        public int SaveChanges()
        {
            return this.TwitterDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.TwitterDbContext.SaveChangesAsync();
        }

        private IRepository<T> GetRepository<T>() where T : BaseModel<int>
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(Repository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.TwitterDbContext);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
