
namespace DomoticzIntegration.Service.Models
{
    public class GetPropertiesResponse
    {
        public int ActTime { get; set; }
        public string AstrTwilightEnd { get; set; }
        public string AstrTwilightStart { get; set; }
        public string CivTwilightEnd { get; set; }
        public string CivTwilightStart { get; set; }
        public string DayLength { get; set; }
        public string NautTwilightEnd { get; set; }
        public string NautTwilightStart { get; set; }
        public string ServerTime { get; set; }
        public string SunAtSouth { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string app_version { get; set; }
        public string status { get; set; }
        public string title { get; set; }

        public DomoticzProperty[] result { get; set; }
    }
}
