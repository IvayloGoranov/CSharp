namespace LinkedIn.Web.ViewModels
{
    using System;
    using Common.Mappings;
    using LinkedIn.Models;

    public class CertificationViewModel : IMapFrom<Certification>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LicenseNumber { get; set; }

        public string Url { get; set; }

        public DateTime TakenDate { get; set; }

        public DateTime ExpirationDate { get; set; }

    }
}
