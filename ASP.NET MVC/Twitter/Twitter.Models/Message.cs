
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class Message : TitleAndContentEntity
    {
        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }
    }
}
