﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UrbanAirSharp.Response;

namespace UrbanAirSharp.Request.Base
{
	public class PutRequest<TResponse, TContent> : BaseRequest<TResponse> where TResponse : BaseResponse, new()
	{
        public readonly Encoding Encoding = Encoding.UTF8;
        public const string MediaType = "application/json";

        protected TContent Content;

		public PutRequest(TContent content, ServiceModelConfig serviceModelConfig)
			: base(serviceModelConfig.Host, serviceModelConfig.HttpClient, serviceModelConfig.SerializerSettings)
        {
			RequestMethod = HttpMethod.Put;
            Content = content;
        }

		public override async Task<TResponse> ExecuteAsync()
        {
            var json = JsonConvert.SerializeObject(Content, SerializerSettings);

            var response = await HttpClient.PutAsync(Host + RequestUrl, new StringContent(json, Encoding, MediaType));

            return await DeserializeResponseAsync(response);
        }
    }
}
