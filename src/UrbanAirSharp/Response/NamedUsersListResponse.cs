using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanAirSharp.Dto;

namespace UrbanAirSharp.Response
{
    public class NamedUsersListResponse : BaseResponse
    {
        [JsonProperty("next_page")]
        public string NextPageRequestUrl { get; set; }
        [JsonProperty("named_users")]
        public IList<NamedUser> NamedUsers { get; set; }
    }
}
