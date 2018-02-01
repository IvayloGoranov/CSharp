using Razor.PageModels;

namespace SharpStore.PageModels
{
    public class AboutPage : Page
    {
        public AboutPage()
            : this(Constants.AboutPagePath)
        {
        }

        public AboutPage(string htmlPath)
            : base(htmlPath)
        {
            this.AddStyleToHtml(Constants.BootstrapInjectionLink);
        }
    }
}