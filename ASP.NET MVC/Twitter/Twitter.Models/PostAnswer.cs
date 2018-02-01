using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class PostAnswer : BaseModel<int>
    {
        //[ForeignKey("Answer")]
        //[Index("IX_ParentPostId_AnswerId", 1, IsUnique = true)]
        public int AnswerId { get; set; }

        //[ForeignKey("Post")]
        //[Index("IX_ParentPostId_AnswerId", 2, IsUnique = true)]
        public int ParentPostId { get; set; }

        //[ForeignKey("AnswerId")]
        public virtual Post Answer { get; set; }

        //[ForeignKey("ParentPostId")]
        public virtual Post Post { get; set; }
    }
}
