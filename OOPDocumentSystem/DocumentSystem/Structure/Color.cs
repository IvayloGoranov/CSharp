using DocumentSystem.Interfaces;
using System.IO;

namespace DocumentSystem
{
    public class Color : IHTMLRenderer
    {
        public static readonly Color Red = new Color(255, 50, 50);
        public static readonly Color Green = new Color(51, 102, 0);
        public static readonly Color Blue = new Color(50, 50, 255);
        public static readonly Color White = new Color(255, 255, 255);
        public static readonly Color Black = new Color(0, 0, 0);

        public Color(byte redValue = 0, byte greenValue = 0, byte blueValue = 0)
        {
            this.RedValue = redValue;
            this.GreenValue = greenValue;
            this.BlueValue = blueValue;
        }
        
        public byte RedValue { get; private set; }

        public byte GreenValue { get; private set; }

        public byte BlueValue { get; private set; }

        public void RenderHTML(TextWriter writer)
        {
            writer.Write("#" + this.RedValue.ToString("X2") + this.GreenValue.ToString("X2") + this.BlueValue.ToString("X2"));
        }
    }
}
