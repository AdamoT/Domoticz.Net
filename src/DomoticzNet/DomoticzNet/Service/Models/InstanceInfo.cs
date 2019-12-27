
namespace DomoticzIntegration.Service.Models
{
    public class InstanceInfo
    {
        public string DomoticzUpdateURL { get; set; }
        public bool HaveUpdate { get; set; }
        public int Revision { get; set; }
        public string SystemName { get; set; }
        public bool UseUpdate { get; set; }
        public string build_time { get; set; }
        public string dzvents_version { get; set; }
        public string hash { get; set; }
        public string python_version { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string version { get; set; }
    }
}
