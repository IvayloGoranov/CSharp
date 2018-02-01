using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

using BookShopSystem.Models;

namespace BookShopSystem.Server.Api.DTOs.ViewModels
{
    public class BookViewModel
    {
        public static Expression<Func<Book, BookViewModel>> MapToViewModel
        {
            get
            {
                return x => new BookViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Edition = x.Edition,
                    Price = x.Price,
                    Copies = x.Copies,
                    ReleaseDate = x.ReleaseDate,
                    AgeRestriction = x.AgeRestriction,
                    AuthorName = x.Author.LastName,
                    CategoryNames = x.Categories.AsQueryable().Select(c => c.CategoryName)
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Edition Edition { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public string AuthorName { get; set; }

        public IEnumerable<string> CategoryNames { get; set; }
    }
}