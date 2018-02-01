namespace AutomappingLive.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BookAuthor
    {

        [Key, Column(Order = 1)]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Key, Column(Order = 2)]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [Key, Column(Order = 0)]
        public string Name { get; set; }
    }
}
