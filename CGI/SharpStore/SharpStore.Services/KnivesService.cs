using System.Collections.Generic;
using System.Linq;
using SharpStore.Data;
using SharpStore.Data.Models;
using SharpStore.Utils;

namespace SharpStore.Services
{
    public class KnivesService
    {
        private SharpStoreContext context;

        public KnivesService()
        {
            this.context = new SharpStoreContext();
        }

        public IList<Knive> GetKnivesByNamesFromUrl(string url)
        {
            int variableSeparatorIndex = url.IndexOf('?');
            if (variableSeparatorIndex != -1)
            {
                string queryString = url.Substring(variableSeparatorIndex + 1);
                IDictionary<string, string> variables = VariablesExtractor.ExtractVariables(queryString);
                var knifeName = variables["product-name"];
                return this.context.Knives.Where(knive => knive.Name.Contains(knifeName)).ToList();
            }

            return this.context.Knives.ToList();
        }
    }
}
