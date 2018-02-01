namespace ReaperInvasion.UI
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public sealed class AssetLoader
    {
        private static readonly AssetLoader instance = new AssetLoader();

        private Image reaperImage;

        private AssetLoader()
        {
        }

        public static AssetLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public Image GetImage(AssetType type)
        {
            if (this.reaperImage == null)
            {
                this.reaperImage = new Image();
                reaperImage.Source = this.LoadImage(type);
            }

            return this.reaperImage;
        }

        private ImageSource LoadImage(AssetType type)
        {
            string path = string.Empty;

            switch (type)
            {
                case AssetType.Reaper:
                    path = AssetPaths.ReaperImage;
                    break;
                default: 
                    throw new ArgumentException("Unsupported asset type.");
            }

            var src = new Uri(path, UriKind.Relative);

            return BitmapFrame.Create(src);
        }
    }
}
