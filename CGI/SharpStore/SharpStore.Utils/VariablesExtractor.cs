using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace SharpStore.Utils
{
    public class VariablesExtractor
    {
        public static IDictionary<string, string> ExtractVariables(string queryString)
        {
            queryString = WebUtility.UrlDecode(queryString);
            Dictionary<string, string> data = new Dictionary<string, string>();

            string[] variables = queryString.Split(new char[] { '&' });
            if (variables.Length == 0)
            {
                variables[0] = queryString;
            }

            foreach (string variable in variables)
            {
                string[] tokens = variable.Split('=');
                data.Add(tokens[0], tokens[1]);
            }

            return data;
        }
    }
}