using System;
using System.ComponentModel.DataAnnotations;

using BookShopSystem.Models;

namespace BookShopSystem.Server.Api.DTOs.InputModels
{
    public class BookInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public Edition Edition { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public int AuthorId { get; set; }

        public string CategoryNames { get; set; }

        internal Book UpdateBook(Book bookToEdit)
        {
            bookToEdit.Title = this.Title;
            bookToEdit.Description = this.Description;
            bookToEdit.Edition = this.Edition;
            bookToEdit.Price = this.Price;
            bookToEdit.Copies = this.Copies;
            bookToEdit.ReleaseDate = this.ReleaseDate;
            bookToEdit.AgeRestriction = this.AgeRestriction;

            return bookToEdit;
        }

        internal Book CreateBook()
        {
            var newBook = new Book
            {
                Title = this.Title,
                Description = this.Description,
                Edition = this.Edition,
                Price = this.Price,
                Copies = this.Copies,
                ReleaseDate = this.ReleaseDate,
                AgeRestriction = this.AgeRestriction
            };

            return newBook;
        }
    }
}