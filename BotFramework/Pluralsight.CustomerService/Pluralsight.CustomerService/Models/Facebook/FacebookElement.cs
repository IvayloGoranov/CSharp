using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.CustomerService.Models.Facebook
{
    public class FacebookElement
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [DataMember]
        public FacebookButton[] buttons { get; set; }

        [JsonProperty(PropertyName = "default_action")]
        [DataMember]
        public FacebookButton DefaultAction { get; set; }
    }
}
