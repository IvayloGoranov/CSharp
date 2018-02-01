using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

using OnlineShop.Models;

namespace OnlineShop.Server.Api.Models
{
    public class AdViewModel
    {
        public static Expression<Func<Ad, AdViewModel>> MapToViewModel
        {
            get
            {
                return x => new AdViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    PostedOn = x.PostedOn,
                    Status = x.Status,
                    OwnerId = x.OwnerId,
                    OwnerUsername = x.Owner.UserName,
                    AdTypeName = x.Type.Name,
                    Categories = x.Categories.AsQueryable().Select(CategoryViewModel.MapToViewModel)
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime PostedOn { get; set; }

        public AdStatus Status { get; set; }

        public string OwnerId { get; set; }

        public string OwnerUsername { get; set; }

        public string AdTypeName { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}