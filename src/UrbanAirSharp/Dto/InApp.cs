using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanAirSharp.Dto
{
    /// <summary>
    /// Class describing an in-app message.
    /// </summary>
    public class InApp
    {
        /// <summary>
        /// The text displayed on the in-app message.
        /// </summary>
        [JsonProperty("alert")]
        public string Alert { get; set; }

        /// <summary>
        /// Specifies the display type. Currently, the only valid option is "banner".
        /// </summary>
        [JsonProperty("display_type")]
        public string DisplayType => "banner";

        /// <summary>
        /// A Display Object specifying the exact display of the in-app message.
        /// </summary>
        [JsonProperty("display")]
        public Display Display { get; set; }

        /// <summary>
        /// Expiry of the In-App message.
        /// </summary>
        [JsonProperty("expiry")]
        public DateTime? Expiry { get; set; }
    }
}
