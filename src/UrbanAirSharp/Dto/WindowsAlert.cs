// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)
using System;
using Newtonsoft.Json;

namespace UrbanAirSharp.Dto
{
	public class WindowsAlert : BaseAlert
	{
		[JsonProperty("toast")]
		public string Toast { get; set; }

		[JsonProperty("tile")]
		public string Tile { get; set; }

		[JsonProperty("badge")]
		public string Badge { get; set; }
	}
}