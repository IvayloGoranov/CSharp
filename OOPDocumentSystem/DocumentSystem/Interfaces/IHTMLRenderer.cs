using System.IO;

namespace DocumentSystem.Interfaces
{
    public interface IHTMLRenderer
    {
        void RenderHTML(TextWriter writer);
    }
}
