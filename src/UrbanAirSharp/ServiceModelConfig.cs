using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UrbanAirSharp
{
	public class ServiceModelConfig
	{
		public readonly String Host = "https://go.urbanairship.com/";
		public readonly HttpClient HttpClient = new HttpClient();
		public readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings();

	    public static ServiceModelConfig Create(String uaAppKey, String uaAppMAsterSecret)
	    {
	        return new ServiceModelConfig(uaAppKey, uaAppMAsterSecret);
	    }

        public ServiceModelConfig(String uaAppKey, String uaAppMAsterSecret)
        {
            var auth = String.Format("{0}:{1}", uaAppKey, uaAppMAsterSecret);
            auth = Convert.ToBase64String(Encoding.ASCII.GetBytes(auth));

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/vnd.urbanairship+json; version=3;");
            //System.Net.ServicePointManager.Expect100Continue = false;
            SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
			SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
			SerializerSettings.DateParseHandling = DateParseHandling.DateTime;
			SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
			SerializerSettings.DateFormatString = "yyyy-MM-ddTH:mm:ss";
		}
	}
}
