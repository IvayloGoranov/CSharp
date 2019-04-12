using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.CustomerService.Models.Facebook
{
    public class FacebookSendMessage
    {
        public string text { get; set; }

        public string notification_type { get; set; }

        public FacebookAttachment attachment { get; set; }

        public FacebookQuickReply[] quick_replies { get; set; }
    }

    public class FacebookAttachment
    {
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FacebookAttachmentTypes Type { get; set; }

        [JsonProperty(PropertyName = "payload")]
        public FacebookPayload Payload { get; set; }
    }

    public enum FacebookAttachmentTypes
    {
        template,
        audio,
        image,
        video,
        file
    }

    public class FacebookQuickReply
    {
        [JsonProperty(PropertyName = "content_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FacebookContentTypes ContentType { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "payload")]
        public string Payload { get; set; }
    }

    public enum FacebookContentTypes
    {
        text,
        location
    }
}
