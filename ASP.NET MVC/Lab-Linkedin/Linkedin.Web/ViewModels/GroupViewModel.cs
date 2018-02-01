using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using LinkedIn.Common.Mappings;
    using LinkedIn.Data.Models;

    public class GroupViewModel : IMapFrom<Group>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public GroupType Type { get; set; }

        public string OwnerId { get; set; }

        public string Website { get; set; }
    }
}