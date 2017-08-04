using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanAirSharp.Dto
{
    public class TagGroups
    {
        [JsonProperty("ua_background_enabled")]
        public List<string> UABackgroundEnabled { get; set; }

        [JsonProperty("ua_opt_in")]
        public List<string> UAOptIn { get; set; }
    }
}
