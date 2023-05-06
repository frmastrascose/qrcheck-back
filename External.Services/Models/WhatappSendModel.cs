using Newtonsoft.Json;
using System.Text.Json;

namespace External.Services.Models
{
    public class WhatappSendModel
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("contents")]
        public List<WhatsappContentModel> Contents { get; set; }
    }

    public class WhatsappContentModel
    {
        [JsonProperty("type")]
        public string Type { get { return "text"; } }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
