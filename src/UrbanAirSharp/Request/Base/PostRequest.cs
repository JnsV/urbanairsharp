// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UrbanAirSharp.Response;

namespace UrbanAirSharp.Request.Base
{
	/// <summary>
	/// Used to form a VALIDATE request
	/// Accept the same range of payloads as /api/push, but parse and validate only, without sending any pushes
	/// 
	/// http://docs.urbanairship.com/reference/api/v3/push.html
	/// </summary>
	public class PostRequest<TResponse, TContent> : BaseRequest<TResponse> where TResponse : BaseResponse, new()
	{
		//TODO: PostRequest shouldn't declate this - should be more abstract
		public readonly Encoding Encoding = Encoding.UTF8;
		public const string MediaType = "application/json";

		protected TContent Content;
		
		public PostRequest(TContent content, ServiceModelConfig serviceModelConfig)
			: base(serviceModelConfig.Host, serviceModelConfig.HttpClient, serviceModelConfig.SerializerSettings)
		{
			RequestMethod = HttpMethod.Post;
			Content = content;
		}

		public override async Task<TResponse> ExecuteAsync()
		{
			var json = JsonConvert.SerializeObject(Content, SerializerSettings);

            StringContent httpContent = new StringContent(json, Encoding, MediaType);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

		    using (var response = await HttpClient.PostAsync(Host + RequestUrl, httpContent))
		    {
		        return await DeserializeResponseAsync(response);
		    }
		}
	}
}
