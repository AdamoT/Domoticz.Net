using DomoticzNet.Models;
using DomoticzNet.Parser;
using DomoticzNet.Parser.Traits;
using DomoticzNet.Service;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DomoticzNetTests
{
    [TestClass]
    public class TestParser
    {
        private static List<DomoticzDeviceModel> _TestDevicesSet = null;
        private static List<IDomoticzTrait> _TestParsedTraits = null;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var testDevicesFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "resources/TestGetDevicesResponse.json");
            var testDevicesSerialized = File.ReadAllText(testDevicesFilePath);

            var devicesResponse = JsonConvert.DeserializeObject<DomoticzNet.Models.GetDevicesResponse>(testDevicesSerialized, DomoticzService.SerializerSettings);

            _TestDevicesSet = devicesResponse.Devices
                .Where(x => x.Used)
                .ToList();

            _TestParsedTraits = new List<IDomoticzTrait>();
            var parser = new DomoticzDeviceParser();
            parser.ParseTraits(_TestDevicesSet, _TestParsedTraits);
        }

        [DataTestMethod]
        [DataRow(2)]
        [DataRow(5)]
        [DataRow(6)]
        public void TestMiLightRgbw(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            var onOffTrait = traits.OfType<OnOffTrait>().FirstOrDefault();
            var levelTrait = traits.OfType<LevelTrait>().FirstOrDefault();
            var colorSettingTrait = traits.OfType<ColorSettingTrait>().FirstOrDefault();

            Assert.IsNotNull(onOffTrait);
            Assert.IsNotNull(levelTrait);
            Assert.IsNotNull(colorSettingTrait);

            Assert.IsFalse(onOffTrait.IsReadOnly, "OnOff");
            Assert.IsFalse(levelTrait.IsReadOnly, "Level");
        }

        [DataTestMethod]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        [DataRow(21)]
        [DataRow(28)]
        [DataRow(122)]
        public void TestWritableOnOffSwitch(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            Assert.AreEqual(1, traits.Count);

            var onOffTrait = traits[0] as OnOffTrait;
            Assert.IsNotNull(onOffTrait);
            Assert.IsFalse(onOffTrait.IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(11)]
        public void TestWritableLevelOnOffSwitches(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            Assert.AreEqual(2, traits.Count);

            var onOffTrait = traits.OfType<OnOffTrait>().FirstOrDefault();
            var levelTrait = traits.OfType<LevelTrait>().FirstOrDefault();

            Assert.IsNotNull(onOffTrait);
            Assert.IsNotNull(levelTrait);

            Assert.IsFalse(onOffTrait.IsReadOnly);
            Assert.IsFalse(levelTrait.IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(16)]
        [DataRow(81)]
        [DataRow(92)]
        [DataRow(103)]
        public void TestWritableLevelOnOffSwitchesWithBattery(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            Assert.AreEqual(3, traits.Count);

            var onOffTrait = traits.OfType<OnOffTrait>().FirstOrDefault();
            var levelTrait = traits.OfType<LevelTrait>().FirstOrDefault();
            var batteryTrait = traits.OfType<BatteryTrait>().FirstOrDefault();

            Assert.IsNotNull(onOffTrait);
            Assert.IsNotNull(levelTrait);
            Assert.IsNotNull(batteryTrait);

            Assert.IsFalse(onOffTrait.IsReadOnly);
            Assert.IsFalse(levelTrait.IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(23)]
        [DataRow(84)]
        [DataRow(95)]
        [DataRow(106)]
        public void TestThermostatMode(int idx)
        {
            throw new NotImplementedException();
        }

        [DataTestMethod]
        [DataRow(50)]
        [DataRow(51)]
        [DataRow(52)]
        [DataRow(56)]
        [DataRow(57)]
        [DataRow(58)]
        [DataRow(59)]
        [DataRow(60)]
        [DataRow(61)]
        [DataRow(70)]
        [DataRow(74)]
        [DataRow(78)]
        [DataRow(120)]
        [DataRow(123)]
        [DataRow(124)]
        public void TestReadOnlyOnOffSensors(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            Assert.AreEqual(1, traits.Count);

            var onOffTrait = traits.OfType<OnOffTrait>().FirstOrDefault();

            Assert.IsNotNull(onOffTrait);

            Assert.IsTrue(onOffTrait.IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(20)]
        [DataRow(38)]
        [DataRow(53)]
        [DataRow(54)]
        [DataRow(55)]
        public void TestReadOnlyValueSensors(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            Assert.AreEqual(1, traits.Count);

            var sensorTrait = traits.OfType<SensorTrait>().FirstOrDefault();

            Assert.IsNotNull(sensorTrait);

            Assert.AreNotEqual(UnitType.Unknown, sensorTrait.Unit);
        }

        [DataTestMethod]
        [DataRow(91)]
        [DataRow(102)]
        [DataRow(113)]
        public void TestReadOnlyValueSensorsWithBattery(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            Assert.AreEqual(2, traits.Count);

            var sensorTrait = traits.OfType<SensorTrait>().FirstOrDefault();
            var batteryTrait = traits.OfType<BatteryTrait>().FirstOrDefault();

            Assert.IsNotNull(sensorTrait);
            Assert.IsNotNull(batteryTrait);

            Assert.AreNotEqual(UnitType.Unknown, sensorTrait.Unit);
        }

        [DataTestMethod]
        [DataRow(65)]
        public void TestWakeOnLan(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            Assert.AreEqual(1, traits.Count);
            var onOffTrait = traits[0] as OnOffTrait;
            Assert.IsNotNull(onOffTrait);
            Assert.IsFalse(onOffTrait.IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(79)]
        [DataRow(80)]
        [DataRow(85)]
        [DataRow(86)]
        [DataRow(96)]
        [DataRow(97)]
        [DataRow(108)]
        public void TestSetPoint(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            Assert.AreEqual(1, traits.Count);
            var setPointTrait = traits[0] as SetPointTrait;
            Assert.IsNotNull(setPointTrait);
        }

        [DataTestMethod]
        [DataRow(107)]
        public void TestSetpointWithBattery(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);

            Assert.AreEqual(2, traits.Count);
            var setPointTrait = traits.OfType<SetPointTrait>().FirstOrDefault();
            var batteryTrait = traits.OfType<BatteryTrait>().FirstOrDefault();

            Assert.IsNotNull(setPointTrait);
            Assert.IsNotNull(batteryTrait);
        }

        private IReadOnlyList<IDomoticzTrait> GetParsedTraits(ulong idx)
        {
            return _TestParsedTraits.Where(x => x.Id == idx)
                .ToArray();
        }
    }
}