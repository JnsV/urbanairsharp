// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace UrbanAirSharp.Type
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeviceType
    {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "android")]
        Android,
        [EnumMember(Value = "ios")]
        Ios,
        [EnumMember(Value = "wns")]
        Wns,
        [EnumMember(Value = "mpns")]
        Mpns,
        [EnumMember(Value = "blackberry")]
        Blackberry
	}
}
