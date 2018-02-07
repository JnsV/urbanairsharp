// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)

using System;
using UrbanAirSharp.Request.Base;
using UrbanAirSharp.Response;

namespace UrbanAirSharp.Request
{
    /// <summary>
    /// Used to form a TAG delete request
    /// http://docs.urbanairship.com/api/ua.html#deleting-a-tag
    /// </summary>
    [Obsolete("Use new Tags api for channels and named users")]
    public class TagDeleteRequest : DeleteRequest<BaseResponse>
	{
		public TagDeleteRequest(String tag, ServiceModelConfig serviceModelConfig)
            :base(serviceModelConfig)
		{
			RequestUrl = "api/tags/" + tag + "/";
		}
	}
}
