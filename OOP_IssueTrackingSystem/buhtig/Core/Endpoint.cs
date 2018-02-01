using System.Collections.Generic;
using Buhtig.Interfaces;
using System.Net;
using System.Linq;

namespace Buhtig.Core
{
    public class Endpoint : IEndpoint
    {
        public Endpoint(string url)
        {
            this.Parse(url);
        }
        
        public string ActionName { get; private set; }
        
        public IDictionary<string, string> Parameters { get; private set; }

        private void Parse(string url)
        {
            int questionMark = url.IndexOf('?');

            if (questionMark != -1)
            {
                //PERFORMANCE: Fixed unnecessary intialization of a duplicate dictionary to hold parameters by removing it.

                this.ActionName = url.Substring(0, questionMark);
                this.Parameters = new Dictionary<string, string>();

                string[] parameterPairs = url.Substring(questionMark + 1).Split('&');

                foreach (var pair in parameterPairs)
                {
                    string[] nameAndValue = pair.Split('=');
                    string name = WebUtility.UrlDecode(nameAndValue[0]);
                    string value = WebUtility.UrlDecode(nameAndValue[1]);

                    this.Parameters.Add(name, value);
                }
            }
            else
            {
                this.ActionName = url;
            }
        }
    }
}
