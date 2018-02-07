using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UrbanAirSharp.Dto.Json;

namespace UrbanAirSharp.Dto
{
    [JsonConverter(typeof(NamedUserTagUpdateConverter))]
    public class NamedUserTagUpdate
    {
        public List<string> NamedUserIds { get; set; }

        public List<TagGroup> AddedTagGroups { get; set; }

        public List<TagGroup> RemoveTagGroups { get; set; }

        public List<TagGroup> SetTagGroups { get; set; }
    }
}
