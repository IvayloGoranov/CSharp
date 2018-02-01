using Razor.PageModels;

namespace SharpStore.PageModels
{
    public class HomePage : Page
    {
        public HomePage(string htmlPath) 
            : base(htmlPath)
        {
            this.AddStyleToHtml(Constants.BootstrapInjectionLink);
            this.AddStyleToHtml(Constants.CarouselCssPath);
        }

        public HomePage() 
            : this(Constants.HomePagePath)
        {
        }
    }
}
