namespace DomoticzNet.Models
{
    public enum UnitType
    {
        Unknown = 0,

        TemperatureStart = 100,
        Celcius,
        Kelvin,
        Fahrenheit,
        TemperatureEnd = 200,

        VoltageStart,
        Volt,
        KiloVolt,
        VoltageEnd = 300,

        PowerStart,
        Wat,
        KiloWat,
        PowerEnd = 400,

        PowerCurrentStart,
        Amper,
        PowerCurrentEnd = 500,
    }
}
