using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopSystem.Models
{
    public class Purchase
    {
        private ICollection<Book> purchasedBooks;

        public Purchase()
        {
            this.purchasedBooks = new HashSet<Book>();       
        }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<Book> PurchasedBooks
        {
            get
            {
                return this.purchasedBooks;
            }

            set
            {
                this.purchasedBooks = value;
            }
        }
    }
}
