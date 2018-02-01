using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Twitter.Data.Interfaces;
using Twitter.Models;
using Twitter.Models.Interfaces;

namespace Twitter.Data
{
    public class TwitterDBContext : IdentityDbContext<User>, ITwitterDBContext
    {
        public TwitterDBContext()
            : base("TwitterDBContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new TwitterInitializer());
        }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<PostFavourite> PostFavourites { get; set; }

        public IDbSet<PostAnswer> PostAnswers { get; set; }

        public IDbSet<Following> Followings { get; set; }

        public IDbSet<UserImage> UserImages { get; set; }

        public static TwitterDBContext Create()
        {
            return new TwitterDBContext();
        }

        public override int SaveChanges()
        {
            this.SetDateTimeToNewlyCreatedOrModifiedEntities();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            this.SetDateTimeToNewlyCreatedOrModifiedEntities();

            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.Followers).WithMany(x => x.Followings)
            //    .Map(x => x.ToTable("Followers")
            //    .MapLeftKey("UserId")
            //    .MapRightKey("FollowerId"));

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany(t => t.MessagesSent)
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                    .HasRequired(m => m.Receiver)
                    .WithMany(t => t.MessagesReceived)
                    .HasForeignKey(m => m.ReceiverId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                   .HasOptional(x => x.Question)
                   .WithMany(x => x.ChildPosts)
                   .HasForeignKey(x => x.QuestionID);

            modelBuilder.Entity<PostAnswer>()
                    .HasRequired(m => m.Post)
                    .WithMany(t => t.Answers)
                    .HasForeignKey(m => m.ParentPostId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostAnswer>().HasRequired(m => m.Post)
                                 .WithMany(m => m.Answers).HasForeignKey(m => m.ParentPostId);
            modelBuilder.Entity<PostAnswer>().HasRequired(m => m.Answer)
                                        .WithMany().HasForeignKey(m => m.AnswerId);

            modelBuilder.Entity<Following>().HasRequired(m => m.User)
                                 .WithMany(m => m.Followers).HasForeignKey(m => m.UserId)
                                 .WillCascadeOnDelete(false);
            modelBuilder.Entity<Following>().HasRequired(m => m.Follower)
                                        .WithMany(m => m.Followings).HasForeignKey(m => m.FollowerId);

            base.OnModelCreating(modelBuilder);
        }

        private void SetDateTimeToNewlyCreatedOrModifiedEntities()
        {
            var addedOrModifiedEntities = this.ChangeTracker.Entries()
                        .Where(
                        e =>
                        e.Entity is IModifiableEntity &&
                        ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in addedOrModifiedEntities)
            {
                var entity = (IModifiableEntity)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}