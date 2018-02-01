using Razor.PageModels;

namespace SharpStore.PageModels
{
    class ContactsPage : Page
    {
        public ContactsPage(string htmlPath) 
            : base(htmlPath)
        {
            this.AddStyleToHtml(Constants.BootstrapInjectionLink);
        }

        public ContactsPage() : this(Constants.ContactsPagePath) { }
    }
}
