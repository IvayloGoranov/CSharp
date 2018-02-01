namespace AutomappingLive.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.AccessControl;

    public class Book
    {

        public Book()
        {
            this.MappingTable = new List<BookAuthor>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<BookAuthor> MappingTable { get; set; }
    }
}
