using System.Collections.Generic;
using System.Text;
using Razor.PageModels;
using SharpStore.Data.Models;

namespace SharpStore.PageModels
{
    public class ProductsPage : Page
    {
        private IList<Knive> knives;

        public ProductsPage(string htmlPath, IList<Knive> knives) 
            : base(htmlPath)
        {
            this.knives = knives;
            this.AddStyleToHtml(Constants.BootstrapInjectionLink);
        }

        public ProductsPage() 
            : this(Constants.ProductsPagePath, new List<Knive>()) { }

        public ProductsPage(IList<Knive> knives)
            :this()
        {
            this.knives = knives;
        }

        private string GetProductsTemplate()
        {
            StringBuilder products = new StringBuilder();
            foreach (Knive knife in this.knives)
            {
                products.AppendLine($"<div class=\"col-sm-4\">\r\n\t\t\t\t" +
                                    $"<div class=\"thumbnail\">\r\n\t\t\t\t  " +
                                    $"<img src=\"{knife.ImageUrl}\">\r\n\t\t\t\t  " +
                                    $"<div class=\"caption\">\r\n\t\t\t\t\t" +
                                    $"<h3>{knife.Name}</h3>\r\n\t\t\t\t\t" +
                                    $"<p>${knife.Price}</p>\r\n\t\t\t\t\t" +
                                    $"<p><a href=\"#\" class=\"btn btn-primary\" role=\"button\">Buy Now" +
                                    $"</a></p>\r\n\t\t\t\t  " +
                                    $"</div>\r\n\t\t\t\t<" +
                                    $"/div>\r\n\t\t\t\t\r\n\t\t\t" +
                                    $"</div>");
            }

            return products.ToString();
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), this.GetProductsTemplate());
        }
    }
}
