
namespace Exporter.Interfaces
{
    public interface IFileAppender
    {
        ILayout Layout { get; set; }

        string FilePath { get; set; }

        void Append(object obj);
    }
}
