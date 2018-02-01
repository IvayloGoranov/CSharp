using System;
using System.IO;


namespace DocumentSystem
{
    public class Image : Element
    {
        public Image(ImageType type, byte[] data)
        {
            this.ImageType = type;
            this.Data = data;
        }

        public ImageType ImageType { get; private set; }

        public byte[] Data { get; private set; }

        public static Image CreateFromFile(string fileName)
        {
            ImageType type = ImageType.CreateFromFileName(fileName);
            byte[] data = File.ReadAllBytes(fileName);
            Image image = new Image(type, data);

            return image;
        }

        public override void RenderHTML(TextWriter writer)
        {
            writer.Write("<img src='data:{0};base64, {1}'/>", 
                this.ImageType.ContentType, Convert.ToBase64String(this.Data));
        }

        public override void RenderText(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine("[image]");
            writer.WriteLine();
        }
    }
}
