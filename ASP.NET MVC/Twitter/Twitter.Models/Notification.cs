using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class Notification : TitleAndContentEntity
    {
        public NotificationType NotificationType { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
