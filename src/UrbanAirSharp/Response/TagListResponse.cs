﻿// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UrbanAirSharp.Response
{
	public class TagListResponse : BaseResponse
	{
		[JsonProperty("tags")]
		public List<string> Tags { get; set; }
	}
}
