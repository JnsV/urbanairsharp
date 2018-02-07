using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace UrbanAirSharp.Dto.Json
{
    public class NamedUserTagUpdateConverter : JsonConverter
    {
        public override bool CanConvert(System.Type objectType)
        {
            return typeof(NamedUserTagUpdate).IsAssignableFrom(objectType);
        }

        public override bool CanRead => false;

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var inputObject = (NamedUserTagUpdate)value;
            dynamic resultObject = new ExpandoObject();

            resultObject.audience = new ExpandoObject();
            resultObject.audience.named_user_id = inputObject.NamedUserIds.ToArray();

            if (inputObject.AddedTagGroups?.Count > 0)
            {
                resultObject.add = new ExpandoObject();
                foreach (var tagGroup in inputObject.AddedTagGroups)
                {
                    AddProperty(resultObject.add, tagGroup.GroupName, tagGroup.Tags.ToArray());
                }
            }

            if (inputObject.RemoveTagGroups?.Count > 0)
            {
                resultObject.remove = new ExpandoObject();
                foreach (var tagGroup in inputObject.RemoveTagGroups)
                {
                    AddProperty(resultObject.remove, tagGroup.GroupName, tagGroup.Tags.ToArray());
                }
            }

            if (inputObject.SetTagGroups?.Count > 0)
            {
                resultObject.set = new ExpandoObject();
                foreach (var tagGroup in inputObject.SetTagGroups)
                {
                    AddProperty(resultObject.set, tagGroup.GroupName, tagGroup.Tags.ToArray());
                }
            }

            var json = JsonConvert.SerializeObject(resultObject);

            writer.WriteRaw(json);
        }

        private static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
    }
}
