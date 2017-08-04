using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanAirSharp.Type;

namespace UrbanAirSharp.Dto
{
    public class Association
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("device_type")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty("named_user_id")]
        public string NamedUserId { get; set; }

        public Association(string ChannelId, DeviceType DeviceType, string NamedUserId)
        {
            this.ChannelId = ChannelId;
            this.NamedUserId = NamedUserId;
            this.DeviceType = DeviceType;
        }
    }
}
