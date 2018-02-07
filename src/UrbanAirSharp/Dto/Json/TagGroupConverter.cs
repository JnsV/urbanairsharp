using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanAirSharp.Dto.Json
{
    public class NamedListConverter : JsonConverter
    {
        public override bool CanConvert(System.Type objectType)
        {
            return typeof(NamedList).IsAssignableFrom(objectType);
        }

        public override bool CanRead => false;

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                var namedList = (NamedList)value;

                o.AddFirst(new JProperty(namedList.ListName, new JArray(namedList.ElementList)));

                o.WriteTo(writer);
            }
        }
    }
}
