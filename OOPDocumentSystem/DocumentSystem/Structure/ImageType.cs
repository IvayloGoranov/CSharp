using System.IO;
using System;

namespace DocumentSystem
{
    public class ImageType
    {
        private ImageType(string name)
        {
            this.Name = name;
        }
        
        public string Name { get; private set; }

        public static ImageType Png 
        {
            get
            {
                return new ImageType("png");
            }
        }

        public static ImageType Gif
        {
            get
            {
                return new ImageType("gif");
            }
        }

        public static ImageType Jpeg
        {
            get
            {
                return new ImageType("jpeg");
            }
        }

        public string ContentType 
        {
            get
            {
                return "image/" + this.Name;
            }
        }

        public static ImageType CreateFromFileName(string fileName)
        {
            string fileExtension = new FileInfo(fileName).Extension;

            switch (fileExtension.ToLower())
            {
                case ".png":
                    return ImageType.Png;
                case ".jpg":
                case ".jpeg":
                    return ImageType.Jpeg;
                case ".gif":
                    return ImageType.Gif;
                default:
                    throw new NotSupportedException(string.Format("Image extension type {0} not supported.", fileExtension));
            }
        }
    }
}
