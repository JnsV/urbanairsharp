// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)

using System;
using UrbanAirSharp.Request.Base;
using UrbanAirSharp.Response;

namespace UrbanAirSharp.Request
{
    /// <summary>
    /// Used to form a TAG listing request
    /// http://docs.urbanairship.com/api/ua.html#get--api-tags-
    /// </summary>
    [Obsolete("Use new Tags api for channels and named users")]
    public class TagListRequest : GetRequest<TagListResponse>
	{
		public TagListRequest(ServiceModelConfig serviceModelConfig)
            : base(serviceModelConfig)
		{
			RequestUrl = "api/tags/";
		}
	}
}
