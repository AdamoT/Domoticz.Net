namespace DomoticzNet.Service.Models
{
    public enum UnitType
    {
        TemperatureStart = 0,
        Celcius,
        Kelvin,
        Fahrenheit,
        TemperatureEnd = 100,

        VoltageStart,
        Volt,
        KiloVolt,
        VoltageEnd = 200,

        PowerStart,
        Wat,
        KiloWat,
        PowerEnd = 300,

        PowerCurrentStart,
        Amper,
        PowerCurrentEnd = 400,
    }
}
