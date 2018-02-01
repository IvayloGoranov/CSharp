
namespace Twitter.Models.Interfaces
{
    public interface ITitleAndContentEntity : IDeletableEntity, IModifiableEntity
    {
        string Title { get; set; }

        string Content { get; set; }
    }
}
