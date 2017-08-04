using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanAirSharp.Dto
{
    public class NamedUser
    {
        [JsonProperty("named_user_id")]
        public string NamedUserId { get; set; }

        [JsonProperty("tags")]
        public Dictionary<string,string> Tags { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("last_modified")]
        public string LastModified { get; set; }

        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }
    }
}
