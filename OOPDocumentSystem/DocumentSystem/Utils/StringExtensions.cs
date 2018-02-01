using System.Web;

namespace DocumentSystem
{
    public static class StringExtensions
    {
        public static string HtmlEncode(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
    }
}
