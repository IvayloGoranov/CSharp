using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopSystem.Models
{
    public class Book
    {
        private ICollection<Category> categories;
        private ICollection<Book> relatedBooks;

        public Book()
        {
            this.categories = new HashSet<Category>();
            this.relatedBooks = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public Edition Edition { get; set; }

        [Range(typeof(decimal), "0", "decimal.MaxValue")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public DateTime ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public ICollection<Book> RelatedBooks
        {
            get
            {
                return this.relatedBooks;
            }

            set
            {
                this.relatedBooks = value;
            }
        }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public ICollection<Category> Categories
        {
            get
            {
                return this.categories;
            }

            set
            {
                this.categories = value;
            }
        }
    }
}
