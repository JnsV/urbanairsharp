using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanAirSharp.Type;

namespace UrbanAirSharp.Dto
{
    public class Channel
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("device_type")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty("installed")]
        public bool Installed { get; set; }

        [JsonProperty("opt_in")]
        public bool OptIn { get; set; }

        [JsonProperty("background")]
        public bool Background { get; set; }

        [JsonProperty("push_address")]
        public string PushAddress { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("last_registration")]
        public string LastRegistration { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("tz")]
        public string Timezone { get; set; }

        [JsonProperty("tags")]
        public List<object> Tags { get; set; }

        [JsonProperty("tag_groups")]
        public TagGroups TagGroups { get; set; }
    }
}
