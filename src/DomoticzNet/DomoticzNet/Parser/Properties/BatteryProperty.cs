namespace DomoticzNet.Parser.Properties
{
    public class BatteryProperty : PropertyBase
    {
        public byte BatteryPercentage { get; }

        public BatteryProperty(ulong id, byte batteryPercentage) : base(id)
        {
            BatteryPercentage = batteryPercentage;
        }
    }
}
