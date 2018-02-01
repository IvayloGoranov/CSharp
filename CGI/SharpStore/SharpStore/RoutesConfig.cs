using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using Razor.PageModels;
using SharpStore.Data.Models;
using SharpStore.PageModels;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleHttpServer.Routes.RouteHandlers;
using SharpStore.Services;
using SharpStore.Utils;

namespace SharpStore
{
    public class RoutesConfig
    {
        private static IList<Route> routes;

        public static IList<Route> Routes
        {
            get
            {
                return routes ?? new List<Route>()
            {
                   new Route()
                   {Name = "Home Directory",
                    Method = RequestMethod.GET,
                    UrlRegex = Constants.ThemeChangeRegex,
                    Callable = (request) =>
                    {
                        var indexOfQuestion = request.Url.IndexOf('?');
                        IDictionary<string, string> themeDict = VariablesExtractor.ExtractVariables(request.Url.Substring(indexOfQuestion + 1));
                        var htmlFileName = request.Url.Substring(1, indexOfQuestion - 1);  
                        var typeOfWantedPage = Assembly.GetAssembly(typeof(HomePage))
                                    .GetTypes()
                                    .FirstOrDefault(type =>
                                        type.Name.Contains(
                                                htmlFileName[0].ToString().ToUpper()
                                                + htmlFileName.Substring(1)));

                        Page instance = (Page)Activator.CreateInstance(typeOfWantedPage);
                        instance.AddStyleToHtml($"../../content/css/{themeDict["theme"]}.css");
                        var responce = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = instance.ToString()
                        };

                        responce.Header.Cookies.Add(new Cookie("theme", themeDict["theme"]));

                        return responce;
                    }
    },
                new Route()
                {
                    Name = "Home Directory",
                    Method = RequestMethod.GET,
                    UrlRegex = Constants.HomePageRegex,
                    Callable = (request) =>
                    {
                        Page page = new HomePage();
                        page.request = request;
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = page.ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "CSS",
                    Method = RequestMethod.GET,
                    UrlRegex = Constants.CssRegex,
                    Callable = (request) =>
                    {
                        string styleFileName = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText($"../../content/css/{styleFileName}")
                        };
                        response.Header.ContentType = Constants.CssContentType;
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap JS",
                    Method = RequestMethod.GET,
                    UrlRegex = Constants.BootstrapJsRegex,
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText(Constants.BootstrapJsPath)
                        };
                        response.Header.ContentType = Constants.JsContentType;
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Carousel CSS",
                    Method = RequestMethod.GET,
                    UrlRegex = Constants.BootstrapCssRegex,
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText(Constants.BootstrapCssPath)
                        };
                        response.Header.ContentType = Constants.CssContentType;
                        return response;
                    }
                },
                new Route()
                {
                    Name = "About Us",
                    Method = RequestMethod.GET,
                    UrlRegex = Constants.AboutPageRegex,
                    Callable = (request) =>
                    {
                        var page = new AboutPage();
                        page.request = request;
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = page.ToString()
                        };
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Products",
                    Method = RequestMethod.GET,
                    UrlRegex = Constants.ProductsPageRegex,
                    Callable = (request) =>
                    {
                        KnivesService service = new KnivesService();
                        IList<Knive> knives = service.GetKnivesByNamesFromUrl(request.Url);
                        var page = new ProductsPage(knives);
                        page.request = request;
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,

                            ContentAsUTF8 = page.ToString()
                        };
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Contacts",
                    Method = RequestMethod.GET,
                    UrlRegex = Constants.ContactsPageRegex,
                    Callable = (request) =>
                    {
                        Page page = new ContactsPage();
                        page.request = request;
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = page.ToString()
                        };
                        return response;
                    }
                },
                 new Route()
                {
                    Name = "ContactsPOST",
                    Method = RequestMethod.POST,
                    UrlRegex = Constants.ContactsPageRegex,
                    Callable = (request) =>
                    {
                        MessagesService service = new MessagesService();
                        service.AddMessageFromFormData(request.Content);

                        var page = new ContactsPage();
                        page.request = request;
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = page.ToString()
                        };
                        return response;
                    }
                },
                 new Route {
                    Name = "FileSystem Static Handler",
                    UrlRegex = Constants.FileSystemHandlerRegex,
                    Method = RequestMethod.GET,
                    Callable = new FileSystemRouteHandler() {RouteUrlRegex = @"^/(.*)$", BasePath = @"C:\Repo"}.Handle,
                }
            };
            }
        }
    }
}
