using System.Collections.Generic;

using SimpleHttpServer.Models;
using SimpleHttpServer.Enums;
using SimpleHttpServer;

namespace ServerRunner
{
    public class ServerRunner
    {
        public static void Main()
        {
            var route = new Route()
            {
                Name = "Hello Handler",
                UrlRegex = @"^/hello$",
                Method = RequestMethod.GET,
                Callable = (HttpRequest request) => {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "<h3>Hello from HttpServer</h3>",
                        StatusCode = ResponseStatusCode.OK
                    };
                }
            };
            var routes = new List<Route>();
            routes.Add(route);

            HttpServer server = new HttpServer(8081, routes);
            server.Listen();
        }
    }
}
