using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanAirSharp.Dto
{
    public class NamedUserTagUpdate
    {
        [JsonIgnore]
        public List<string> NamedUserIds { get; set; }

        [JsonProperty("audience")]
        public IReadOnlyList<NamedList> Audience
        {
            get
            {
                return new List<NamedList> { new NamedList { ListName = "named_user_id", ElementList = NamedUserIds } }.AsReadOnly();
            }
        }

        [JsonProperty("add")]
        public List<NamedList> AddedTagGroups { get; set; }

        [JsonProperty("remove")]
        public List<NamedList> RemoveTagGroups { get; set; }

        [JsonProperty("set")]
        public List<NamedList> SetTagGroups { get; set; }
    }
}
