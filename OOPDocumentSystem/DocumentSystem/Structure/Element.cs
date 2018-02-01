using DocumentSystem.Interfaces;
using System.IO;

namespace DocumentSystem
{
    public abstract class Element : IHTMLRenderer, ITextRenderer
    {
        public string AsHTML 
        {
            get
            {
                StringWriter stringWriter = new StringWriter();
                this.RenderHTML(stringWriter);
                return stringWriter.ToString();
            } 
        }

        public string AsText
        {
            get
            {
                StringWriter stringWriter = new StringWriter();
                this.RenderText(stringWriter);
                return stringWriter.ToString();
            }
        }

        public abstract void RenderHTML(TextWriter writer);

        public abstract void RenderText(TextWriter writer);

        public override string ToString()
        {
            return this.AsText;
        }
    }
}
