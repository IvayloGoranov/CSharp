namespace LinkedIn.Web.Infrastructure.HtmlHelpers
{
    using System.Web.Mvc;

    using HtmlTags;

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string imageUrl, string alt)
        {
            TagBuilder imageTag = new TagBuilder("img");
            imageTag.MergeAttribute("src", imageUrl);
            imageTag.MergeAttribute("alt", alt);

            return new MvcHtmlString(imageTag.ToString());
        }

        public static HtmlTag TextBoxTag(this HtmlHelper helper, string name)
        {
            return new HtmlTag("input")
                .Id(name)
                .Attr("name", name)
                .Attr("type", "text")
                .Attr("value", helper.ViewData[name]);
        }
    }
}