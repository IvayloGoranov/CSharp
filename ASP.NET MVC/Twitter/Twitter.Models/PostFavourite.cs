using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class PostFavourite : BaseModel<int>
    {
        [ForeignKey("User")]
        [Index("IX_UserId_PostId", 1, IsUnique = true)]
        [Index]
        public string UserId { get; set; }

        [ForeignKey("Post")]
        [Index("IX_UserId_PostId", 2, IsUnique = true)]
        [Index]
        public int PostId { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}
