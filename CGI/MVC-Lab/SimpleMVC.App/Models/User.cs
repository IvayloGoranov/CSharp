using System.Collections.Generic;

namespace SimpleMVC.App.Models
{
    public class User
    {
        public User()
        {
            this.Notes = new HashSet<Note>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Passsword { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
