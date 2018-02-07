using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UrbanAirSharp.Dto.Json;

namespace UrbanAirSharp.Dto
{
    [JsonConverter(typeof(NamedListConverter))]
    public class NamedList
    {
        public string ListName { get; set; }

        public List<string> ElementList { get; set; }
    }
}
