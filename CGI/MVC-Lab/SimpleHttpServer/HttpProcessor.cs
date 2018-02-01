using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleHttpServer
{
    public class HttpProcessor
    {
        private IList<Route> routes;
        private HttpRequest request;
        private HttpResponse response;
        private IDictionary<string, HttpSession> sessions;

        public HttpProcessor(IEnumerable<Route> routes, IDictionary<string, HttpSession> sessions)
        {
            this.routes = new List<Route>(routes);
            this.sessions = sessions;
        }

        public void HandleClient(TcpClient tcpClient)
        {
            using (var stream = tcpClient.GetStream())
            {
                request = GetRequest(stream);
                response = RouteRequest();
                Console.WriteLine("-RESPONSE-------------");
                Console.WriteLine(response.Header);
                //Console.WriteLine(Encoding.UTF8.GetString(Response.Content));
                Console.WriteLine("----------------------");
                StreamUtils.WriteResponse(stream, response);
            }
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
                else if (name == "Location")
                {
                    header.Location = value;
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

            if (request.Header.Cookies.Contains("sessionId"))
            {
                var sessionId = request.Header.Cookies["sessionId"].Value;
                request.Session = new HttpSession(sessionId);
                if (!this.sessions.ContainsKey(sessionId))
                {
                    this.sessions.Add(sessionId, request.Session);
                }
            }

            Console.WriteLine("-REQUEST-----------------------------");
            Console.WriteLine(request);
            Console.WriteLine("------------------------------");

            return request;
        }
        private HttpResponse RouteRequest()
        {
            var routes = this.routes
                .Where(x => Regex.Match(request.Url, x.UrlRegex).Success)
                .ToList();

            if (!routes.Any())
                return HttpResponseBuilder.NotFound();

            var route = routes.FirstOrDefault(x => x.Method == request.Method);

            if (route == null)
                return new HttpResponse()
                {
                    StatusCode = ResponseStatusCode.MethodNotAllowed
                };

            // trigger the route handler...
            try
            {
                if (this.request.Session == null)
                {
                    var session = SessionCreator.Create();
                    this.request.Session = session;
                }

                var response = route.Callable(request);

                if (!request.Header.Cookies.Contains("sessionId"))
                {
                    var sessionCookie = new Cookie("sessionId", this.request.Session.Id + "; HttpOnly; path=/");
                    response.Header.AddCookie(sessionCookie);
                }

                return response;
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
