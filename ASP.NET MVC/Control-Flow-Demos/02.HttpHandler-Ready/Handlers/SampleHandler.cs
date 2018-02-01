using System.Web;

namespace _02.HttpHandler_Ready.Handlers
{
    public class SampleHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<p>This is our sample handler</p>");
        }
    }
}