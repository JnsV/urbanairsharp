﻿// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)

using UrbanAirSharp.Dto;
using UrbanAirSharp.Request.Base;
using UrbanAirSharp.Response;

namespace UrbanAirSharp.Request
{
	/// <summary>
	/// Used to form a PUSH request
	/// http://docs.urbanairship.com/reference/api/v3/push.html
	/// </summary>
	public class PushRequest : PostRequest<PushResponse, Push>
	{
		public PushRequest(Push push, ServiceModelConfig serviceModelConfig)
			: base(push, serviceModelConfig)
		{
			RequestUrl = "api/push/";
		}
	}
}
