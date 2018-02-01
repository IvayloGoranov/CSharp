
using System.IO;
namespace DocumentSystem
{
    public class Paragraph : CompositeElement
    {
        public Paragraph()
            : base()
        {
        }

        public Paragraph(string text, Font font = null)
            : this()
        {
            this.AddElement(new TextElement(text, font));
        }
        
        public string Text { get; private set; }

        public Font Font { get; private set; }

        public override void RenderHTML(TextWriter writer)
        {
            writer.Write("<p>");
            base.RenderHTML(writer);
            writer.WriteLine("</p>");
        }

        public override void RenderText(TextWriter writer)
        {
            writer.WriteLine();
            base.RenderText(writer);
            writer.WriteLine();
        }
    }
}
