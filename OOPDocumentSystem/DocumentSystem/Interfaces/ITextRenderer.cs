using System.IO;

namespace DocumentSystem.Interfaces
{
    public interface ITextRenderer
    {
        void RenderText(TextWriter writer);
    }
}
