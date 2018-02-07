using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UrbanAirSharp.Dto.Json;

namespace UrbanAirSharp.Dto
{
    public class TagGroup
    {
        public string GroupName { get; set; }

        public List<string> Tags { get; set; }
    }
}
