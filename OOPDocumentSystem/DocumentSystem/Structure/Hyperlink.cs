
using System.IO;
namespace DocumentSystem
{
    public class Hyperlink : CompositeElement
    {
        public Hyperlink(string url, string text = null)
        {
            this.Url = url;
            this.AddElement(new TextElement(text));
        }
        
        public string Text { get; private set; }

        public string Url { get; private set; }

        public override void RenderHTML(TextWriter writer)
        {
            writer.Write("<a href='{0}'>", this.Url.HtmlEncode());
            if (this.ChildElements.Count > 0)
            {
                base.RenderHTML(writer);
            }
            else
            {
                writer.Write(this.Text);
            }

            writer.Write("</a>");
        }

        public override void RenderText(System.IO.TextWriter writer)
        {
            writer.Write("[url={0}>", this.Url);
            base.RenderHTML(writer);
            writer.Write("[/url]");
        }
    }
}
