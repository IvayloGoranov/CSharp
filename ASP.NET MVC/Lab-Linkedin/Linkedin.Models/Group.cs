namespace LinkedIn.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LinkedIn.Models;

    public class Group : IEntity
    {
        private ICollection<User> members;
        private ICollection<Discussion> discussions;

        public Group()
        {
            this.members = new HashSet<User>();
            this.discussions = new HashSet<Discussion>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public GroupType Type { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public string Website { get; set; }

        public virtual ICollection<User> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public virtual ICollection<Discussion> Discussions
        {
            get { return this.discussions; }
            set { this.discussions = value; }
        }
    }
}