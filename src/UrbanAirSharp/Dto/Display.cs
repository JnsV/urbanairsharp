using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace UrbanAirSharp.Dto
{
    /// <summary>
    /// Position of in-app message within screen.
    /// </summary>
    public enum EDisplayPosition
    {
        /// <summary>
        /// Top of screen.
        /// </summary>
        [EnumMember(Value = "top")]
        Top,

        /// <summary>
        /// Bottom of screen.
        /// </summary>
        [EnumMember(Value = "bottom")]
        Bottom
    }

    /// <summary>
    /// Class describing the details of an in-app message.
    /// </summary>
    public class Display
    {
        private Color _primaryColor;
        private Color _secondaryColor;

        /// <summary>
        /// Specifies the primary color of the in-app message.
        /// </summary>
        [JsonIgnore]
        public Color PrimaryColor
        {
            get
            {
                return _primaryColor;
            }
            set
            {
                _primaryColor = value;
            }
        }

        /// <summary>
        /// Specifies the secondary color of the in-app message.
        /// </summary>
        [JsonIgnore]
        public Color SecondaryColor
        {
            get
            {
                return _secondaryColor;
            }
            set
            {
                _secondaryColor = value;
            }
        }

        /// <summary>
        /// Specifies the primary color of the in-app message in HTML format #RRGGBB.
        /// </summary>
        [JsonProperty("primary_color")]
        public string PrimaryColorHtml
        {
            get
            {
                return _primaryColor.ToHtml();
            }
            set
            {
                _primaryColor = value.ToColor();
            }
        }

        /// <summary>
        /// Specifies the primary color of the in-app message in HTML format #RRGGBB.
        /// </summary>
        [JsonProperty("secondary_color")]
        public string SecondaryColorHtml
        {
            get
            {
                return _secondaryColor.ToHtml();
            }
            set
            {
                _secondaryColor = value.ToColor();
            }
        }

        /// <summary>
        /// One of either "top" or "bottom", specifies the screen position of the message.
        /// </summary>
        [JsonProperty("position")]
        public EDisplayPosition Position { get; set; }

        /// <summary>
        /// Specifies how long the notification should stay on the screen in seconds before automatically disappearing; set to 15 by default.
        /// </summary>
        [JsonProperty("duration")]
        public int? Duration { get; set; }
    }

    internal static class ColorExtensions {
        public static string ToHtml(this Color color)
        {
            return $"#{color.R.ToString("X2")}{color.G.ToString("X2")}{color.B.ToString("X2")}";
        }

        public static Color ToColor(this string htmlString)
        {
            return Color.FromArgb(int.Parse(htmlString.Replace("#", ""), System.Globalization.NumberStyles.AllowHexSpecifier));
        }
    }
}
