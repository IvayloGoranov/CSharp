using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

using BookShopSystem.Models;

namespace BookShopSystem.Server.Api.DTOs.ViewModels
{
    public class AuthorViewModel
    {
        public static Expression<Func<Author, AuthorViewModel>> MapToViewModel
        {
            get
            {
                return x => new AuthorViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BookTitles = x.Books.AsQueryable().Select(b => b.Title)
                };
            }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> BookTitles { get; set; }
    }
}