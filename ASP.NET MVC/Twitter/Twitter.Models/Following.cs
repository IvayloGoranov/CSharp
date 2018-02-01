using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class Following : BaseModel<int>
    {
        //[Index("IX_UserId_FollowerId", 1, IsUnique = true)]
        public string UserId { get; set; }

        //[Index("IX_UserId_FollowerId", 2, IsUnique = true)]
        public string FollowerId { get; set; }

        public virtual User User { get; set; }

        public virtual User Follower { get; set; }
    }
}
