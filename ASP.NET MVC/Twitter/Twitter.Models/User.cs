using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

using Twitter.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    
    public class User : IdentityUser, IDeletableEntity, IModifiableEntity
    {
        private ICollection<Following> followers;
        private ICollection<Following> followings;
        private ICollection<Post> posts;
        private ICollection<Message> messagesSent;
        private ICollection<Message> messagesReceived;
        private ICollection<Notification> notifications;
        private ICollection<PostFavourite> postFavourites;

        public User()
        {
            this.followers = new HashSet<Following>();
            this.followings = new HashSet<Following>();
            this.posts = new HashSet<Post>();
            this.messagesSent = new HashSet<Message>();
            this.messagesReceived = new HashSet<Message>();
            this.notifications = new HashSet<Notification>();
        }

        [StringLength(100, ErrorMessage = "The Full name must be between {1} and {2} characters long.", 
            MinimumLength = 2)]
        public string FullName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} name must be between {1} and {2} characters long.",
            MinimumLength = 10)]
        public string Summary { get; set; }

        [Index]
        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual UserImage Avatar { get; set; }

        public virtual ICollection<Following> Followers
        {
            get
            {
                return this.followers;
            }

            set
            {
                this.followers = value;
            }
        }

        public virtual ICollection<Following> Followings
        {
            get
            {
                return this.followings;
            }

            set
            {
                this.followings = value;
            }
        }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }

            set
            {
                this.posts = value;
            }
        }

        public virtual ICollection<Message> MessagesSent
        {
            get
            {
                return this.messagesSent;
            }

            set
            {
                this.messagesSent = value;
            }
        }

        public virtual ICollection<Message> MessagesReceived
        {
            get
            {
                return this.messagesReceived;
            }

            set
            {
                this.messagesReceived = value;
            }
        }

        public virtual ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }

            set
            {
                this.notifications = value;
            }
        }

        public virtual ICollection<PostFavourite> PostFavourites
        {
            get
            {
                return this.postFavourites;
            }

            set
            {
                this.postFavourites = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = 
                await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
