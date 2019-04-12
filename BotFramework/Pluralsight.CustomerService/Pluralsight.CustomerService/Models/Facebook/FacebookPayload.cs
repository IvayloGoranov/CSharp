using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.CustomerService.Models.Facebook
{
    [Serializable]
    public class FacebookPayload
    {
        [JsonProperty(PropertyName = "template_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FacebookTemplateTypes TemplateType { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        // Used for Audio, Files, Images, and Videos
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "top_element_style")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FacebookListTopElementStyle? TopElementStyle { get; set; }

        [JsonProperty(PropertyName = "elements")]
        public FacebookElement[] Elements { get; set; }

        [JsonProperty(PropertyName = "buttons")]
        public FacebookButton[] Buttons { get; set; }
    }
    public enum FacebookTemplateTypes
    {
        button,
        generic,
        receipt,
        carousel,
        list
    }
    public enum FacebookListTopElementStyle
    {
        compact,
        large
    }
}
