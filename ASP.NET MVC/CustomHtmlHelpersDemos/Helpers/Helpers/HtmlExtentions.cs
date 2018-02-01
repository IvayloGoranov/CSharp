using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace Helpers.Helpers
{
    public static class HtmlExtentions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string imageUrl, string alt = null, string width = "150px",
            string height = "150px")
        {
            TagBuilder builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            if (alt != null)
            {
                builder.MergeAttribute("alt", alt);
            }

            builder.MergeAttribute("width", width);
            builder.MergeAttribute("height", height);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString YouTube(this HtmlHelper helper, string videoId, int width = 600, int height = 400)
        {
            TagBuilder builder = new TagBuilder("iframe");
            builder.MergeAttribute("width", $"{width}");
            builder.MergeAttribute("height", $"{height}");
            builder.MergeAttribute("src", $"https://www.youtube.com/embed/{videoId}");
            builder.MergeAttribute("frameborder", "0");
            builder.MergeAttribute("allowfullscreen", "allowfullscreen");


            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Table<T>(this HtmlHelper helper, IEnumerable<T> models, params string[] cssClasses)
        {
            TagBuilder table = new TagBuilder("table");
            StringBuilder tableInnerHtml = new StringBuilder();
            string[] propertyNames = typeof(T).GetProperties().Select(info => info.Name).ToArray();
            foreach (string cssClass in cssClasses)
            {
                table.AddCssClass(cssClass);
            }

            TagBuilder tableHeaderRow = new TagBuilder("tr");
            StringBuilder tableHeaderInnerHtml = new StringBuilder();
            foreach (string propertyName in propertyNames)
            {
                TagBuilder tableData = new TagBuilder("th");
                tableData.InnerHtml = propertyName;
                tableHeaderInnerHtml.Append(tableData);
            }
            tableHeaderRow.InnerHtml = tableHeaderInnerHtml.ToString();
            tableInnerHtml.Append(tableHeaderRow);

            foreach (var model in models)
            {
                TagBuilder tableDataRow = new TagBuilder("tr");
                StringBuilder tableDataRowInnerHtml = new StringBuilder();
                foreach (string propertyName in propertyNames)
                {
                    TagBuilder tableData = new TagBuilder("td");
                    tableData.InnerHtml = typeof(T).GetProperty(propertyName).GetValue(model).ToString();
                    tableDataRowInnerHtml.Append(tableData);
                }

                tableDataRow.InnerHtml = tableDataRowInnerHtml.ToString();
                tableInnerHtml.Append(tableDataRow);
            }
            table.InnerHtml = tableInnerHtml.ToString();
                                        
            return new MvcHtmlString(table.ToString(TagRenderMode.Normal));
        }
    }
}
