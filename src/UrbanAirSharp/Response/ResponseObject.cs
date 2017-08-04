using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UrbanAirSharp.Response
{
    /// <summary>
    /// Simple Base-Response Object supporting retrieval of unknown properties.
    /// </summary>
    public abstract class ResponseObject {
        /// <summary>
        /// Properties not known to this object.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }
}
