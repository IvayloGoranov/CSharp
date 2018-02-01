using System.ComponentModel.DataAnnotations;

namespace ModelBinders.Models
{
    public class Address
    {
        [Display(Name = "Град")]
        public string Town { get; set; }

        [Display(Name = "Държава")]
        public string Country { get; set; }
    }
}
