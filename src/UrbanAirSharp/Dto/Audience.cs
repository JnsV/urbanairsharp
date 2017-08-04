// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UrbanAirSharp.Type;

namespace UrbanAirSharp.Dto
{
	public class Audience
	{
		[JsonProperty("apid")]
		public string AndroidDeviceId { get; private set; }

		[JsonProperty("device_token")]
		public string IosDeviceId { get; private set; }

		[JsonProperty("wns")]
		public string WindowsId { get; private set; }

		[JsonProperty("mpns")]
		public string WindowsPhoneId { get; private set; }

		[JsonProperty("device_pin")]
		public string BlackberryId { get; private set; }

		[JsonProperty("segment")]
		public string SegmentId { get; private set; }

		[JsonProperty("alias")]
		public string Alias { get; private set; }

		[JsonProperty("tag")]
		public string Tag { get; private set; }

		[JsonProperty("OR")]
		public IList<Audience> Or { get; private set; }

		[JsonProperty("AND")]
		public IList<Audience> And { get; private set; }

		[JsonProperty("NOT")]
		public Audience Not { get; private set; }

		public Audience()
		{
		}

		public Audience(AudienceType type, string value)
		{
			switch (type)
			{
				case AudienceType.Android:
					AndroidDeviceId = value;
					break;
				case AudienceType.Ios:
					IosDeviceId = value;
					break;
				case AudienceType.Windows:
					WindowsId = value;
					break;
				case AudienceType.WindowsPhone:
					WindowsPhoneId = value;
					break;
				case AudienceType.Blackberry:
					BlackberryId = value;
					break;
				case AudienceType.Segment:
					SegmentId = value;
					break;
				case AudienceType.Alias:
					Alias = value;
					break;
				case AudienceType.Tag:
					Tag = value;
					break;
			}
		}

		public Audience OrAudience(IList<Audience> audiences)
		{
			if (Or != null && audiences != null)
			{
				audiences = Or.Concat(audiences).ToList();
			}

			ClearAudience();

			Or = audiences;

			return this;
		}

		public Audience AndAudience(IList<Audience> audiences)
		{
			if (And != null && audiences != null)
			{
				audiences = And.Concat(audiences).ToList();
			}

			ClearAudience();

			And = audiences;

			return this;
		}

		public Audience NotAudience(Audience audience)
		{
			ClearAudience();

			Not = audience;

			return this;
		}

		public void ClearAudience()
		{
			AndroidDeviceId = null;
			IosDeviceId = null;
			WindowsId = null;
			WindowsPhoneId = null;
			BlackberryId = null;
			SegmentId = null;
			Alias = null;
			Tag = null;
			Or = null;
			And = null;
			Not = null;
		}
	}
}
