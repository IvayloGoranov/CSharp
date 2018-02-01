using System;
using System.IO;

namespace DocumentSystem
{
    public class Heading : Element
    {
        public Heading(string text, int size = 1)
        {
            if (size <= 0 || size > 6)
            {
                throw new ArgumentException("size", "The heading size should be in range [1..6].");
            }

            this.HeadingSize = size;
            this.Text = text;
        }
        
        public int HeadingSize { get; private set; }

        public string Text { get; private set; }
        
        public override void RenderHTML(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine("<h{0}>{1}</h{0}>", this.HeadingSize, this.Text.HtmlEncode());
        }

        public override void RenderText(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine(this.Text.ToUpper());
        }
    }
}
