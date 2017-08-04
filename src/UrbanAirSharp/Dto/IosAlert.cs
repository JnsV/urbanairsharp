// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)
using System.Collections.Generic;

using Newtonsoft.Json;

namespace UrbanAirSharp.Dto
{
    public class IosAlert : IosAlert<dynamic> {
        public IosAlert() {
            Badge = "auto";
        }
    }

    /// <summary>
    /// An iOS Alert Base Type
    /// </summary>
    /// <typeparam name="TBadge">The type of the badge. We expect this to be <see cref="int"/> or <see cref="string"/>.</typeparam>
    public class IosAlert<TBadge> : BaseAlert {
	    [JsonProperty("badge")]
        public TBadge Badge;

		[JsonProperty("sound")]
		public string Sound { get; set; }

		[JsonProperty("content_available")]
		public bool ContentAvailable { get; set; }

		[JsonProperty("expiry")]
		public int ApnsTimeToLive { get; set; }

		[JsonProperty("priority")] 
		public int Priority = 10;

		[JsonProperty("extra")]
		public Dictionary<string, string> Extras { get; set; }
	}
}