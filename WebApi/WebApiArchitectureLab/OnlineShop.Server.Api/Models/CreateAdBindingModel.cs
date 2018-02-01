using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

using OnlineShop.Models;

namespace OnlineShop.Server.Api.Models
{
    public class CreateAdBindingModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int TypeId { get; set; }

        public IEnumerable<int> Categories { get; set; }

        internal Ad CreateAd()
        {
            var newAd = new Ad
            {
                Name = this.Name,
                Description = this.Description,
                Price = this.Price,
                PostedOn = DateTime.Now
            };

            return newAd;
        }
    }
}