using System.CodeDom;

namespace SharpStore
{
    class Constants
    {
        #region Pages constants   

        public const string AboutPagePath = "../../content/about.html";
        public const string ContactsPagePath = "../../content/contacts.html";
        public const string HomePagePath = "../../content/home.html";
        public const string ProductsPagePath = "../../content/products.html";
        public const string BootstrapInjectionLink = "bootstrap/css/bootstrap.min.css";
        public const string CarouselCssPath = "../../content/css/carousel.css";
        public const string BootstrapCssPath = "../../content/bootstrap/css/bootstrap.min.css";
        public const string BootstrapJsPath = "../../content/bootstrap/js/bootstrap.min.js";

        #endregion

        #region UrlRegex constants

        public const string HomePageRegex = "^/home$";
        public const string AboutPageRegex = "^/about$";
        public const string ProductsPageRegex = "^/products.*$";
        public const string ContactsPageRegex = "^/contacts";
        public const string FileSystemHandlerRegex = @"^/(.*)$";
        public const string CssRegex = "^/content/css/.+.css$";
        public const string BootstrapJsRegex = "^/bootstrap/js/bootstrap.min.js$";
        public const string BootstrapCssRegex = "^/bootstrap/css/bootstrap.min.css$";
        public const string ThemeChangeRegex = "^/.+?\\?theme=.+$";

        #endregion

        #region Content type constants

        public const string CssContentType = "text/css";
        public const string JsContentType = "application/x-javascript";

        #endregion
    }
}
