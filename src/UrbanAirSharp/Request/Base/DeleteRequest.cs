// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)

using System.Net.Http;
using System.Threading.Tasks;
using UrbanAirSharp.Response;

namespace UrbanAirSharp.Request.Base
{
	public class DeleteRequest<TResponse> : BaseRequest<TResponse> where TResponse : BaseResponse, new()
	{
		public DeleteRequest(ServiceModelConfig serviceModelConfig)
			: base(serviceModelConfig.Host, serviceModelConfig.HttpClient, serviceModelConfig.SerializerSettings)
		{
			RequestMethod = HttpMethod.Delete;
		}

		public override async Task<TResponse> ExecuteAsync()
		{
			var response = await HttpClient.DeleteAsync(Host + RequestUrl);

			return await DeserializeResponseAsync(response);
		}
	}
}
