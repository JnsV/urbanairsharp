// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UrbanAirSharp.Dto
{
	/// <summary>
	/// title - Required
	/// body - Required
	/// content_type - optional MIME type. default is text/html
	/// content_encoding - optional. default is utf8
	/// extra - optional JSON String dictionary 
	/// icons - optional JSON String dictionary. Example : { "list_icon" : "ua:9bf2f510-050e-11e3-9446-14dae95134d2" }
	/// 
	///  http://docs.urbanairship.com/reference/api/v3/richpush.html#rich-push
	/// </summary>
	public class RichMessage
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("content_type")]
		public string ContentType { get; set; }

		[JsonProperty("content_encoding")]
		public string ContentEncoding { get; set; }

		[JsonProperty("extra")]
		public IDictionary<string,string> Extras { get; set; }

		[JsonProperty("icons")]
		public IDictionary<string, string> Icons { get; set; }
	}
}
