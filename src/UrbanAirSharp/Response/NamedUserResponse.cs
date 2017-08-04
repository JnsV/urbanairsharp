using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanAirSharp.Dto;

namespace UrbanAirSharp.Response
{
    public class NamedUserResponse : BaseResponse
    {
        [JsonProperty("named_user")]
        public NamedUser NamedUser { get; set; }
    }
}
