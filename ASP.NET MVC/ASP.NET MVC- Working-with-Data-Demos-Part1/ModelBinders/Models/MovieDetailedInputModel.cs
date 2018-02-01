using System;
using System.ComponentModel.DataAnnotations;

namespace ModelBinders.Models
{
    public class MovieDetailedInputModel
    {
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Display(Name = "Ревю")]
        public string Review { get; set; }

        [Display(Name = "Дължина в минути")]
        public int LengthInMinutes { get; set; }

        [Display(Name = "Дата на премиерата")]
        public DateTime ReleaseDate { get; set; }

        public Address Address { get; set; }
    }
}