namespace LinkedIn.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq.Expressions;
    using Data.Models;
    using LinkedIn.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Common.Mappings;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Име")]
        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public IEnumerable<CertificationViewModel> Certifications { get; set; }

        public IEnumerable<SkillViewModel> Skills { get; set; }
    }
}