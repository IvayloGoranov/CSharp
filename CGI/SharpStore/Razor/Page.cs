using System.Collections.Generic;
using System.IO;
using System.Text;
using SimpleHttpServer.Models;

namespace Razor.PageModels
{
    public abstract class Page
    {
        private const string ThemePath = "../../content/css/{0}.css";

        private StringBuilder htmlOfPage;
        public HttpRequest request { get; set; }

        public Page(string htmlPath)
        {
            this.htmlOfPage = new StringBuilder();
            this.htmlOfPage.Append(File.ReadAllText(htmlPath));
        }

        public void AddStyleToHtml(string stylePath)
        {
            int insertionIndex = htmlOfPage.ToString().IndexOf("</head>");

            this.htmlOfPage = htmlOfPage.Insert(insertionIndex, $"<link href=\"{stylePath}\" rel=\"stylesheet\">");
        }

        public override string ToString()
        {
            if (this.request != null && this.request.Header.Cookies.Contains("theme"))
            {
                this.AddStyleToHtml(string.Format(ThemePath, this.request.Header.Cookies["theme"].Value));
            }

            return this.htmlOfPage.ToString();
        }
    }
}
