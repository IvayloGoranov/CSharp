namespace LinkedIn.Web.ViewModels
{
    using System.Linq.Expressions;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Mappings;

    public class SkillViewModel : IMapFrom<UserSkill>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Endorsers { get; set; }

        public int EndorsementsCount { get; set; }
    }
}
