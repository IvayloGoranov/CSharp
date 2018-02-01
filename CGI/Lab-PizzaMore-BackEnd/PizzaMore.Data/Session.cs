using System.ComponentModel.DataAnnotations;

namespace PizzaMore.Data
{
    public class Session
    {
        [Key]
        public string Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}", this.Id, this.User.Id);
        }
    }
}
