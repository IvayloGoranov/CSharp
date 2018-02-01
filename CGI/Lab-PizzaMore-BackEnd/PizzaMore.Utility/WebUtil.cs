using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;

namespace PizzaMore.Utility
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            var environmentVariable = Environment.GetEnvironmentVariable(GlobalConstants.RequestMethod);
            if (environmentVariable != null)
            {
                string requestMethod = environmentVariable.ToLower();
                if (requestMethod == "post")
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsGet()
        {
            var environmentVariable = Environment.GetEnvironmentVariable(GlobalConstants.RequestMethod);
            if (environmentVariable != null)
            {
                string requestMethod = environmentVariable.ToLower();
                if (requestMethod == "get")
                {
                    return true;
                }
            }

            return false;
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string parametersString = 
                WebUtility.UrlDecode(Environment.GetEnvironmentVariable(GlobalConstants.QueryString));

            return RetrieveRequestParameters(parametersString);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            string parametersString = WebUtility.UrlDecode(Console.ReadLine());

            return RetrieveRequestParameters(parametersString);
        }

        public static ICookieCollection GetCookies()
        {
            string cookieString = Environment.GetEnvironmentVariable(GlobalConstants.CookieGet);
            if (string.IsNullOrEmpty(cookieString))
            {
                return new CookieCollection();
            }

            var cookies = new CookieCollection();
            string[] cookieSaves = cookieString.Split(';');
            foreach (var cookieSave in cookieSaves)
            {
                string[] cookiePair = cookieSave.Split('=').Select(x => x.Trim()).ToArray();
                var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                cookies.AddCookie(cookie);
            }

            return cookies;
        }

        public static string GetSessionId()
        {
            var cookies = GetCookies();
            if (!cookies.ContainsKey(GlobalConstants.SessionIdKey))
            {
                return null;
            }

            var sessionCookie = cookies[GlobalConstants.SessionIdKey];

            return sessionCookie.Value;
        }

        public static void PageNotAllowed()
        {
            PrintFileContent(GlobalConstants.PageNotAllowedPath);
        }

        public static void PrintFileContent(string path)
        {
            string content = File.ReadAllText(path);
            Console.WriteLine(content);
        }

        private static IDictionary<string, string> RetrieveRequestParameters(string parametersString)
        {
            Dictionary<string, string> resultParameters = new Dictionary<string, string>();
            var parameters = parametersString.Split('&');
            foreach (var param in parameters)
            {
                var pair = param.Split('=');
                var name = pair[0];
                string value = null;
                if (pair.Length > 1)
                {
                    value = pair[1];
                }

                resultParameters.Add(name, value);
            }

            return resultParameters;
        }
    }
}
