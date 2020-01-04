namespace DomoticzNet.Parser.Traits
{
    public enum UnitType
    {
        Unknown = 0,
        NotApplicable = 1,

        Percent,

        UnitsStart = 100,
        TemperatureStart,
        Celcius,
        Kelvin,
        Fahrenheit,
        TemperatureEnd = TemperatureStart + 100,

        LightIntensityStart,
        Lux,
        LightIntensityEnd = LightIntensityStart + 100,

        VoltageStart,
        Volt,
        KiloVolt,
        VoltageEnd = VoltageStart + 100,

        PowerStart,
        Watt,
        KiloWatt,
        PowerEnd = PowerStart + 100,

        PowerConsumptionStart,
        KiloWattPerHour,
        PowerConsumptionEnd = PowerConsumptionStart + 100,

        PowerCurrentStart,
        Amper,
        PowerCurrentEnd = PowerCurrentStart + 100,
    }
}
