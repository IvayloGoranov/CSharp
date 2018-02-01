using System.IO;
using System.Web;

namespace DocumentSystem
{
    public class TextElement : Element
    {
        public TextElement(string text, Font font = null)
        {
            this.Text = text;
            this.Font = font;
        }
        
        public string Text { get; private set; }

        public Font Font { get; private set; }

        public override void RenderHTML(TextWriter writer)
        {
            if (this.Font != null)
            {
                writer.Write("<span style='");
                this.Font.RenderHTML(writer);
                writer.WriteLine("'>");
            }

            writer.Write(this.Text.HtmlEncode());
            if (this.Font != null)
            {
                writer.WriteLine("</span>");
            }
        }

        public override void RenderText(TextWriter writer)
        {
            writer.Write(this.Text);
        }
    }
}
