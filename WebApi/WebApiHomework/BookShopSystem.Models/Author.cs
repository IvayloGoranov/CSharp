using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    public class Author
    {
        private ICollection<Book> books;

        public Author()
        {
            this.books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }

            set
            {
                this.books = value;
            }
        }
    }
}
