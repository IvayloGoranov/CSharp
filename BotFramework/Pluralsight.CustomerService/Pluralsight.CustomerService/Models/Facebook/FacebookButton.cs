using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.CustomerService.Models.Facebook
{
    public class FacebookButton
    {
        [JsonProperty(PropertyName = "payload")]
        public string Payload { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FacebookButtonTypes Type { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "webview_height_ratio")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FacebookWebviewHeightRatio? WebviewHeight { get; set; }

        [JsonProperty(PropertyName = "messenger_extensions")]
        public bool? MessageExtensions { get; set; }

        [JsonProperty(PropertyName = "webview_share_button", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(FacebookShareButtonHide.show)]
        [JsonConverter(typeof(StringEnumConverter))]
        public FacebookShareButtonHide? WebviewShareButton { get; set; }

        [JsonProperty(PropertyName = "share_contents")]
        public FacebookSendMessage SharedMessage { get; set; }
    }
    public enum FacebookButtonTypes
    {
        account_link,
        account_unlink,
        element_share,
        payment,
        phone_number,
        postback,
        web_url
    }
    public enum FacebookWebviewHeightRatio
    {
        compact,
        tall,
        full
    }
    public enum FacebookShareButtonHide
    {
        hide,
        show // This value isn't verified and likely doesn't get read. Only 'hide' should have an active effect.
    }
}
