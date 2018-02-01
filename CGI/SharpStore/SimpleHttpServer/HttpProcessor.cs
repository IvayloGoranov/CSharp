using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using SimpleHttpServer.Utilities;

namespace SimpleHttpServer
{
    public class HttpProcessor
    {
        private IList<Route> Routes;
        private HttpRequest Request;
        private HttpResponse Response;

        public HttpProcessor(IEnumerable<Route> routes)
        {
            this.Routes = new List<Route>(routes);
        }

        public void HandleClient(Stream stream)
        {
           
                Request = GetRequest(stream);
                Response = RouteRequest();
                StreamUtils.WriteResponse(stream, Response);
            
        }


        private HttpRequest GetRequest(Stream inputStream)
        {
            //Read Request Line
            string requestLine = StreamUtils.ReadLine(inputStream);
            string[] tokens = requestLine.Split(' ');
            while (tokens.Length != 3)
            {
                requestLine = StreamUtils.ReadLine(inputStream);
                tokens = requestLine.Split(' ');
            }                                   

            RequestMethod method = (RequestMethod)Enum.Parse(typeof(RequestMethod), tokens[0].ToUpper());
            string url = tokens[1];
            string protocolVersion = tokens[2];

            //Read Headers
            Header header = new Header(HeaderType.HttpRequest);
            string line;
            while ((line = StreamUtils.ReadLine(inputStream)) != null)
            {
                if (line.Equals(""))
                {
                    break;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                string name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++;
                }

                string value = line.Substring(pos, line.Length - pos);
                if (name == "Cookie")
                {
                    string[] cookieSaves = value.Split(';');
                    foreach (var cookieSave in cookieSaves)
                    {
                        string[] cookiePair = cookieSave.Split('=').Select(x => x.Trim()).ToArray();
                        var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                        header.AddCookie(cookie);
                    }
                }
                else if (name == "Content-Length")
                {
                    header.ContentLength = value;
                }
                else
                {
                    header.OtherParameters.Add(name, value);
                }
            }



            string content = null;
            if (header.ContentLength != null)
            {
                int totalBytes = Convert.ToInt32(header.ContentLength);
                int bytesLeft = totalBytes;
                byte[] bytes = new byte[totalBytes];

                while (bytesLeft > 0)
                {
                    byte[] buffer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = inputStream.Read(buffer, 0, buffer.Length);
                    buffer.CopyTo(bytes, totalBytes - bytesLeft);

                    bytesLeft -= n;
                }

                content = Encoding.ASCII.GetString(bytes);
            }




            var request = new HttpRequest()
            {
                Method = method,
                Url = url,
                Header = header,
                Content = content
            };
            Console.WriteLine("-REQUEST-----------------------------");
            Console.WriteLine(request);
            Console.WriteLine("------------------------------");

            return request;
        }
        private HttpResponse RouteRequest()
        {
            var routes = this.Routes
                .Where(x => Regex.Match(Request.Url, x.UrlRegex).Success)
                .ToList();

            if (!routes.Any())
                return HttpResponseBuilder.NotFound();

            var route = routes.FirstOrDefault(x => x.Method == Request.Method);

            if (route == null)
                return new HttpResponse()
                {
                    StatusCode = ResponseStatusCode.MethodNotAllowed
                };

            #region FIleSystemHandler
            // extract the path if there is one
            //var match = Regex.Match(request.Url, route.UrlRegex);
            //if (match.Groups.Count > 1)
            //{
            //    request.Path = match.Groups[1].Value;
            //}
            //else
            //{
            //    request.Path = request.Url;
            //}
            #endregion


            // trigger the route handler...
            try
            {
                return route.Callable(Request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return HttpResponseBuilder.InternalServerError();
            }

        }
    }
}
