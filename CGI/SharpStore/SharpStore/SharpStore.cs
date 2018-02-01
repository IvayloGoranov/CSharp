using SimpleHttpServer;
using SimpleHttpServer.Routes;

namespace SharpStore
{
    class SharpStore
    {
        static void Main()
        {                                            
            var routes = RoutesConfig.Routes;

            HttpServer server = new HttpServer(8081, routes);
            server.Listen();
        }
    }
}