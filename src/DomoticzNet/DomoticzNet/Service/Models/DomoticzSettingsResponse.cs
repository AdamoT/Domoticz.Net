using Newtonsoft.Json;

namespace DomoticzNet.Service.Models
{
    public class DomoticzSettingsResponse : CommandResponse
    {
        [JsonProperty("AcceptNewHardware")]
        public long AcceptNewHardware { get; set; }

        [JsonProperty("ActiveTimerPlan")]
        public long ActiveTimerPlan { get; set; }

        [JsonProperty("AllowWidgetOrdering")]
        public long AllowWidgetOrdering { get; set; }

        [JsonProperty("AuthenticationMethod")]
        public long AuthenticationMethod { get; set; }

        [JsonProperty("BatterLowLevel")]
        public long BatterLowLevel { get; set; }

        [JsonProperty("CM113DisplayType")]
        public long Cm113DisplayType { get; set; }

        [JsonProperty("ClickatellAPI")]
        public string ClickatellApi { get; set; }

        [JsonProperty("ClickatellEnabled")]
        public string ClickatellEnabled { get; set; }

        [JsonProperty("ClickatellFrom")]
        public string ClickatellFrom { get; set; }

        [JsonProperty("ClickatellPassword")]
        public string ClickatellPassword { get; set; }

        [JsonProperty("ClickatellTo")]
        public string ClickatellTo { get; set; }

        [JsonProperty("ClickatellUser")]
        public string ClickatellUser { get; set; }

        [JsonProperty("CostEnergy")]
        public string CostEnergy { get; set; }

        [JsonProperty("CostEnergyR1")]
        public string CostEnergyR1 { get; set; }

        [JsonProperty("CostEnergyR2")]
        public string CostEnergyR2 { get; set; }

        [JsonProperty("CostEnergyT2")]
        public string CostEnergyT2 { get; set; }

        [JsonProperty("CostGas")]
        public string CostGas { get; set; }

        [JsonProperty("CostWater")]
        public string CostWater { get; set; }

        [JsonProperty("DashboardType")]
        public long DashboardType { get; set; }

        [JsonProperty("DegreeDaysBaseTemperature")]
        public string DegreeDaysBaseTemperature { get; set; }

        [JsonProperty("DisableDzVentsSystem")]
        public long DisableDzVentsSystem { get; set; }

        [JsonProperty("DoorbellCommand")]
        public long DoorbellCommand { get; set; }

        [JsonProperty("DzVentsLogLevel")]
        public long DzVentsLogLevel { get; set; }

        [JsonProperty("ElectricVoltage")]
        public long ElectricVoltage { get; set; }

        [JsonProperty("EmailAsAttachment")]
        public string EmailAsAttachment { get; set; }

        [JsonProperty("EmailEnabled")]
        public long EmailEnabled { get; set; }

        [JsonProperty("EmailFrom")]
        public string EmailFrom { get; set; }

        [JsonProperty("EmailPassword")]
        public string EmailPassword { get; set; }

        [JsonProperty("EmailPort")]
        public long EmailPort { get; set; }

        [JsonProperty("EmailServer")]
        public string EmailServer { get; set; }

        [JsonProperty("EmailTo")]
        public string EmailTo { get; set; }

        [JsonProperty("EmailUsername")]
        public string EmailUsername { get; set; }

        [JsonProperty("EnableEventScriptSystem")]
        public long EnableEventScriptSystem { get; set; }

        [JsonProperty("EnableTabCustom")]
        public long EnableTabCustom { get; set; }

        [JsonProperty("EnableTabFloorplans")]
        public long EnableTabFloorplans { get; set; }

        [JsonProperty("EnableTabLights")]
        public long EnableTabLights { get; set; }

        [JsonProperty("EnableTabScenes")]
        public long EnableTabScenes { get; set; }

        [JsonProperty("EnableTabTemp")]
        public long EnableTabTemp { get; set; }

        [JsonProperty("EnableTabUtility")]
        public long EnableTabUtility { get; set; }

        [JsonProperty("EnableTabWeather")]
        public long EnableTabWeather { get; set; }

        [JsonProperty("EnergyDivider")]
        public long EnergyDivider { get; set; }

        [JsonProperty("FloorplanActiveOpacity")]
        public long FloorplanActiveOpacity { get; set; }

        [JsonProperty("FloorplanAnimateZoom")]
        public long FloorplanAnimateZoom { get; set; }

        [JsonProperty("FloorplanFullscreenMode")]
        public long FloorplanFullscreenMode { get; set; }

        [JsonProperty("FloorplanInactiveOpacity")]
        public long FloorplanInactiveOpacity { get; set; }

        [JsonProperty("FloorplanPopupDelay")]
        public long FloorplanPopupDelay { get; set; }

        [JsonProperty("FloorplanRoomColour")]
        public string FloorplanRoomColour { get; set; }

        [JsonProperty("FloorplanShowSceneNames")]
        public long FloorplanShowSceneNames { get; set; }

        [JsonProperty("FloorplanShowSensorValues")]
        public long FloorplanShowSensorValues { get; set; }

        [JsonProperty("FloorplanShowSwitchValues")]
        public long FloorplanShowSwitchValues { get; set; }

        [JsonProperty("GCMEnabled")]
        public long GcmEnabled { get; set; }

        [JsonProperty("GasDivider")]
        public long GasDivider { get; set; }

        [JsonProperty("HTTPEnabled")]
        public string HttpEnabled { get; set; }

        [JsonProperty("HTTPField1")]
        public string HttpField1 { get; set; }

        [JsonProperty("HTTPField2")]
        public string HttpField2 { get; set; }

        [JsonProperty("HTTPField3")]
        public string HttpField3 { get; set; }

        [JsonProperty("HTTPField4")]
        public string HttpField4 { get; set; }

        [JsonProperty("HTTPPostContentType")]
        public string HttpPostContentType { get; set; }

        [JsonProperty("HTTPPostData")]
        public string HttpPostData { get; set; }

        [JsonProperty("HTTPPostHeaders")]
        public string HttpPostHeaders { get; set; }

        [JsonProperty("HTTPTo")]
        public string HttpTo { get; set; }

        [JsonProperty("HTTPURL")]
        public string Httpurl { get; set; }

        [JsonProperty("HideDisabledHardwareSensors")]
        public long HideDisabledHardwareSensors { get; set; }

        [JsonProperty("IFTTTAPI")]
        public string Iftttapi { get; set; }

        [JsonProperty("IFTTTEnabled")]
        public long IftttEnabled { get; set; }

        [JsonProperty("KodiEnabled")]
        public string KodiEnabled { get; set; }

        [JsonProperty("KodiIPAddress")]
        public string KodiIpAddress { get; set; }

        [JsonProperty("KodiPort")]
        public long KodiPort { get; set; }

        [JsonProperty("KodiTimeToLive")]
        public long KodiTimeToLive { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }

        [JsonProperty("LightHistoryDays")]
        public long LightHistoryDays { get; set; }

        [JsonProperty("LmsDuration")]
        public long LmsDuration { get; set; }

        [JsonProperty("LmsEnabled")]
        public string LmsEnabled { get; set; }

        [JsonProperty("LmsPlayerMac")]
        public string LmsPlayerMac { get; set; }

        [JsonProperty("Location")]
        public DomoticzLocation Location { get; set; }

        [JsonProperty("LogEventScriptTrigger")]
        public long LogEventScriptTrigger { get; set; }

        [JsonProperty("MobileType")]
        public long MobileType { get; set; }

        [JsonProperty("MyDomoticzSubsystems")]
        public long MyDomoticzSubsystems { get; set; }

        [JsonProperty("MyDomoticzUserId")]
        public string MyDomoticzUserId { get; set; }

        [JsonProperty("NotificationSensorInterval")]
        public long NotificationSensorInterval { get; set; }

        [JsonProperty("NotificationSwitchInterval")]
        public long NotificationSwitchInterval { get; set; }

        [JsonProperty("ProtectionPassword")]
        public string ProtectionPassword { get; set; }

        [JsonProperty("ProwlAPI")]
        public string ProwlApi { get; set; }

        [JsonProperty("ProwlEnabled")]
        public string ProwlEnabled { get; set; }

        [JsonProperty("PushALotAPI")]
        public string PushALotApi { get; set; }

        [JsonProperty("PushALotEnabled")]
        public string PushALotEnabled { get; set; }

        [JsonProperty("PushbulletAPI")]
        public string PushbulletApi { get; set; }

        [JsonProperty("PushbulletEnabled")]
        public long PushbulletEnabled { get; set; }

        [JsonProperty("PushoverAPI")]
        public string PushoverApi { get; set; }

        [JsonProperty("PushoverEnabled")]
        public string PushoverEnabled { get; set; }

        [JsonProperty("PushoverUser")]
        public string PushoverUser { get; set; }

        [JsonProperty("PushsaferAPI")]
        public string PushsaferApi { get; set; }

        [JsonProperty("PushsaferEnabled")]
        public string PushsaferEnabled { get; set; }

        [JsonProperty("PushsaferImage")]
        public string PushsaferImage { get; set; }

        [JsonProperty("RandomTimerFrame")]
        public long RandomTimerFrame { get; set; }

        [JsonProperty("RaspCamParams")]
        public string RaspCamParams { get; set; }

        [JsonProperty("ReleaseChannel")]
        public long ReleaseChannel { get; set; }

        [JsonProperty("RemoteSharedPort")]
        public long RemoteSharedPort { get; set; }

        [JsonProperty("SecOnDelay")]
        public long SecOnDelay { get; set; }

        [JsonProperty("SecPassword")]
        public string SecPassword { get; set; }

        [JsonProperty("SendErrorsAsNotification")]
        public long SendErrorsAsNotification { get; set; }

        [JsonProperty("SensorTimeout")]
        public long SensorTimeout { get; set; }

        [JsonProperty("ShortLogDays")]
        public long ShortLogDays { get; set; }

        [JsonProperty("ShortLogInterval")]
        public long ShortLogInterval { get; set; }

        [JsonProperty("ShowUpdateEffect")]
        public long ShowUpdateEffect { get; set; }

        [JsonProperty("SmartMeterType")]
        public long SmartMeterType { get; set; }

        [JsonProperty("TelegramAPI")]
        public string TelegramApi { get; set; }

        [JsonProperty("TelegramChat")]
        public string TelegramChat { get; set; }

        [JsonProperty("TelegramEnabled")]
        public string TelegramEnabled { get; set; }

        [JsonProperty("TempUnit")]
        public long TempUnit { get; set; }

        [JsonProperty("UVCParams")]
        public string UvcParams { get; set; }

        [JsonProperty("UseAutoBackup")]
        public long UseAutoBackup { get; set; }

        [JsonProperty("UseAutoUpdate")]
        public long UseAutoUpdate { get; set; }

        [JsonProperty("UseEmailInNotifications")]
        public long UseEmailInNotifications { get; set; }

        [JsonProperty("WaterDivider")]
        public long WaterDivider { get; set; }

        [JsonProperty("WebLocalNetworks")]
        public string WebLocalNetworks { get; set; }

        [JsonProperty("WebPassword")]
        public string WebPassword { get; set; }

        [JsonProperty("WebRemoteProxyIPs")]
        public string WebRemoteProxyIPs { get; set; }

        [JsonProperty("WebTheme")]
        public string WebTheme { get; set; }

        [JsonProperty("WebUserName")]
        public string WebUserName { get; set; }

        [JsonProperty("WeightUnit")]
        public long WeightUnit { get; set; }

        [JsonProperty("WindUnit")]
        public long WindUnit { get; set; }

        [JsonProperty("cloudenabled")]
        public bool Cloudenabled { get; set; }

        [JsonProperty("title")]
        public string WelcomeTitle { get; set; }
    }

    public class DomoticzLocation
    {
        [JsonProperty("Latitude")]
        public string Latitude { get; set; }

        [JsonProperty("Longitude")]
        public string Longitude { get; set; }
    }
}
