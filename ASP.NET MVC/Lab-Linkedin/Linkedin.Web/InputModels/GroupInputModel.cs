namespace LinkedIn.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Core.Metadata.Edm;

    using LinkedIn.Data.Models;
    using LinkedIn.Models;

    public class GroupInputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [EnumDataType(typeof(GroupType))]
        public GroupType Type { get; set; }

        public string OwnerId { get; set; }

        public string Website { get; set; }
    }
}