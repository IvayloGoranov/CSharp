namespace AutomappingLive.Models
{
    using System.Collections.Generic;

    public class Author
    {
        public Author()
        {
            this.MappingTable = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BookAuthor> MappingTable { get; set; }
    }
}
