using System.IO;

namespace DocumentSystem.Interfaces
{
    public interface IMSWordRenderer
    {
        void RenderMSWord(Stream writer);
    }
}
