using DocumentSystem.Interfaces;

namespace DocumentSystem
{
    public class Font : IHTMLRenderer
    {
        private const string DefaultFontName = "Arial";
        private const float DefaultFontSize = 12f;
        private const FontStyle DefaultFontStyle = FontStyle.Normal;
        private static readonly Color DefaultFontColor = new Color();

        public Font(string name = DefaultFontName, float size = DefaultFontSize, FontStyle fontStyle = DefaultFontStyle,
            Color color = null)
        {
            this.Name = name;
            this.Size = size;
            this.Style = fontStyle;
            if (color == null)
            {
                this.Color = DefaultFontColor;
            }
            else
            {
                this.Color = color;
            }
        }

        public static Font DefaultFont 
        { 
            get
            {
                return new Font();
            }
        }

        public string Name { get; private set; }

        public float Size { get; private set; }

        public FontStyle Style { get; private set; }

        public Color Color { get; private set; }

        public void RenderHTML(System.IO.TextWriter writer)
        {
            if (this.Name != null)
            {
                writer.Write("font-family:{0};", this.Name);
            }

            if (this.Size != 0)
            {
                writer.Write("font-size:{0}pt;", this.Size);
            }

            if (this.Color != null)
            {
                writer.Write("color:{0};", this.Color);
                this.Color.RenderHTML(writer);
                writer.Write(";");
            }

            if ((this.Style & FontStyle.Bold) != 0)
            {
                writer.Write("font-weight:bold;");
            }

            if ((this.Style & FontStyle.Italic) != 0)
            {
                writer.Write("font-style:italic;");
            }
        }
    }
}
