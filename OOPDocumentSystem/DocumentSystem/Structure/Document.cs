
using System.IO;
namespace DocumentSystem
{
    public class Document : CompositeElement
    {
        public Document()
            : base()
        {
        }

        public Document(params Element[] elements)
            : base(elements)
        {
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public override void RenderHTML(TextWriter writer)
        {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            
            writer.WriteLine("<head>");
            if (this.Title != null)
            {
                writer.WriteLine("<title>{0}</title>", this.Title.HtmlEncode());   
            }
            
            if (this.Author != null)
            {
                writer.WriteLine("<meta name='author' content='{0}' />", this.Author.HtmlEncode());
            }

            writer.WriteLine("</head>");

            writer.WriteLine("<body>");
            base.RenderHTML(writer);
            writer.WriteLine("</body>");

            writer.WriteLine("</html>");
        }

        public override void RenderText(TextWriter writer)
        {
            if (this.Title != null)
            {
                writer.WriteLine("Title: {0}", this.Title);
            }

            if (this.Author != null)
            {
                writer.WriteLine("Author: {0}", this.Author);
            }

            base.RenderText(writer);
        }
    }
}
