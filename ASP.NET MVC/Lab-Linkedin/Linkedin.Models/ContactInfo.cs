namespace LinkedIn.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class ContactInfo
    {
        public string Phone { get; set; }

        public string Twitter { get; set; }

        public string Website { get; set; }

        public string Facebook { get; set; }
    }
}
