using Newtonsoft.Json;

namespace DomoticzNet.Service.Models
{
    public class ColorValue
    {
        [JsonProperty("m")]
        public ColorMode ColorMode { get; set; }

        /// <summary>
        /// Range:0..255, Red level
        /// </summary>
        [JsonProperty("r")]
        public byte Red { get; set; }

        /// <summary>
        /// Range:0..255, Green level
        /// </summary>
        [JsonProperty("g")]
        public byte Green { get; set; }

        /// <summary>
        /// Range:0..255, Blue level
        /// </summary>
        [JsonProperty("b")]
        public byte Blue { get; set; }

        /// <summary>
        /// Range:0..255, Cold white level
        /// </summary>
        [JsonProperty("cw")]
        public byte ColdWhite { get; set; }

        /// <summary>
        /// Range:0..255, Warm white level (also used as level for monochrome white)
        /// </summary>
        [JsonProperty("ww")]
        public byte WarmWhite { get; set; }

        /// <summary>
        /// Range:0..255, Color temperature (warm / cold ratio, 0 is coldest, 255 is warmest)
        /// </summary>
        [JsonProperty("t")]
        public byte Temperature { get; set; }
    }

    public enum ColorMode
    {
        /// <summary>
        /// Illegal
        /// </summary>
        None = 0,
        /// <summary>
        /// White. Valid fields: none
        /// </summary>
        White = 1,
        /// <summary>
        /// White with color temperature. Valid fields: t
        /// </summary>
        WhiteTemperature = 2,
        /// <summary>
        /// Color. Valid fields: r, g, b.
        /// </summary>
        RGB = 3,
        /// <summary>
        /// Custom (color + white). Valid fields: r, g, b, cw, ww, depending on device capabilities
        /// </summary>
        Custom = 4,
    }
}
