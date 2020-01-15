namespace DomoticzNet.Parser.Traits
{
    public enum UnitType
    {
        Unknown = 0,
        NotApplicable,

        ClassStartGeneral = 100,
        OnOff,
        String,
        Percentage,
        ClassEndGeneral = ClassStartGeneral + 100,

        ClassStartTemperature,
        Celcius,
        Fahrenheit,
        Kelvin,
        ClassEndTemperature = ClassStartTemperature + 100,

        ClassStartLightBrightness,
        Lux,
        ClassEndLightBrightness,

        ClassStartSoundLoudness,
        Decibel,
        ClassEndSoundLoudness = ClassStartSoundLoudness + 100,

        ClassStartVoltage,
        Volt,
        KiloVolt,
        ClassEndVoltage = ClassStartVoltage + 100,

        ClassStartPowerCurrent,
        Amper,
        ClassEndPowerCurrent = ClassStartPowerCurrent + 100,

        ClassStartPower,
        Watt,
        KiloWatt,
        ClassEndPower = ClassStartPower + 100,

        ClassStartPowerConsumption,
        WattPerHour,
        KiloWattPerHour,
        ClassEndPowerConsumption = ClassStartPowerConsumption + 100,
    }
}
