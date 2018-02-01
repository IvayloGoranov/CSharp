using Xamarin.Forms;

namespace PagesDemos
{
    public class NamedColor
    {
        public NamedColor(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }

        public string Name { get; private set; }

        public Color Color { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
