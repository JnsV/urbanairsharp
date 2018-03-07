// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UrbanAirSharp.Type;
using UrbanAirSharp.Utils;

namespace UrbanAirSharp.Dto
{
	/// <summary>
	/// Used to form a PUSH request
	/// Send a push notification to a specified device or list of devices
	/// 
	/// audience - Required
	/// notification - Optional, leave as null if you only want to send an in-app message
    /// in_app - Optional
	/// device_types - Required
	/// 
	/// options - optionally specify an expiry date
	/// actions - TODO not supported yet 
	/// message - RICH PUSH message - TODO not supported yet
	/// 
	/// http://docs.urbanairship.com/reference/api/v3/push.html
	/// </summary>
	public class Push
	{
		[JsonProperty("notification")]
		public Notification Notification { get; set; }

        [JsonProperty("in_app")]
        public InApp InApp { get; set; }

        [JsonProperty("audience")]
        private JToken AudienceString {
            get
            {
                return JsonHelper.RemoveEmptyChildren(JToken.FromObject(Audience));
            }
            set
            {
                try
                {
                    _audience = value.ToObject<Audience>();
                }
                catch { }
            }
        }

		private Audience _audience;

        [JsonIgnore]
		public object Audience
		{
			get
			{
				if (_audience == null)
				{
					return "all";
				}

				return _audience;
			}
			set
			{
				var audience = value as Audience;
				_audience = audience;
			}
		}

        [JsonProperty("device_types")]
        private JToken DeviceTypesString
        {
            get
            {
                return JsonHelper.RemoveEmptyChildren(JToken.FromObject(DeviceTypes));
            }
            set
            {
                try
                {
                    _deviceTypes = value.ToObject<IList<DeviceType>>();
                }
                catch { }
            }
        }

        private IList<DeviceType> _deviceTypes;

        [JsonIgnore]
		public object DeviceTypes {
			get 
			{
				if (_deviceTypes == null)
				{
					return "all";
				}
					
				return _deviceTypes;
			}
			set
			{
				var list = value as IList<DeviceType>;
				_deviceTypes = list;
			}
		}

		[JsonProperty("options")]
		public Options Options { get; set; }

		//TODO: not implemented yet
		[JsonProperty("actions")]
		public Actions Actions { get; private set; }

		//TODO: not implemented yet
		[JsonProperty("message")]
		public RichMessage RichMessage { get; private set; }

		public void SetAudience(AudienceType audienceType, string value)
		{
			Audience = new Audience(audienceType, value);
		}
	}
}
