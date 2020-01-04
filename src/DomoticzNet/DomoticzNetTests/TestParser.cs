using DomoticzNet.Models;
using DomoticzNet.Parser;
using DomoticzNet.Parser.Traits;
using DomoticzNet.Service;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

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
        public void TestColorSettingTraits(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);
            traits.RemoveAll(x => x.GetType() == typeof(BatteryTrait));

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
        [DataRow(65)]
        [DataRow(122)]
        public void TestOnOffTraits(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);
            traits.RemoveAll(x => x.GetType() == typeof(BatteryTrait));

            Assert.AreEqual(1, traits.Count);

            var onOffTrait = traits[0] as OnOffTrait;
            Assert.IsNotNull(onOffTrait);
            Assert.IsFalse(onOffTrait.IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(11)]
        [DataRow(16)]
        [DataRow(81)]
        [DataRow(92)]
        [DataRow(103)]
        public void TestLevelOnOffTraits(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);
            traits.RemoveAll(x => x.GetType() == typeof(BatteryTrait));

            Assert.AreEqual(2, traits.Count);

            var onOffTrait = traits.OfType<OnOffTrait>().FirstOrDefault();
            var levelTrait = traits.OfType<LevelTrait>().FirstOrDefault();

            Assert.IsNotNull(onOffTrait);
            Assert.IsNotNull(levelTrait);

            Assert.IsFalse(onOffTrait.IsReadOnly);
            Assert.IsFalse(levelTrait.IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(23)]
        [DataRow(84)]
        [DataRow(95)]
        [DataRow(106)]
        public void TestModeTraits(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);
            traits.RemoveAll(x => x.GetType() == typeof(BatteryTrait));

            Assert.AreEqual(1, traits.Count);

            var modesTrait = traits.OfType<ModeTrait>().FirstOrDefault();

            Assert.IsNotNull(modesTrait);
            Assert.IsTrue(modesTrait.AvailableModes.Count > 0, "More than 0 modes");
            Assert.IsTrue(modesTrait.AvailableModes.ContainsKey(modesTrait.CurrentMode), "Current mode exists in available modes");
        }

        [DataTestMethod]
        [DataRow(50)]
        [DataRow(51)]
        [DataRow(52)]
        [DataRow(56)]
        [DataRow(57)]
        [DataRow(58)]
        [DataRow(59)]
        [DataRow(74)]
        [DataRow(78)]
        [DataRow(120)]
        [DataRow(123)]
        [DataRow(124)]
        public void TestReadOnlyOnOffTraits_NotWorking(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);
            traits.RemoveAll(x => x.GetType() == typeof(BatteryTrait));

            Assert.AreEqual(1, traits.Count);

            var onOffTrait = traits.OfType<OnOffTrait>().FirstOrDefault();

            Assert.IsNotNull(onOffTrait);
            //There is absolutelly no way to tell if the device is read-only (only reports state) or is a onOff switch, even Domoticz UI allows turning on/off those devices altough the should be read-only
            //Assert.IsTrue(onOffTrait.IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(60)]
        [DataRow(61)]
        [DataRow(70)]
        public void TestReadOnlyOnOffTraits(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);
            traits.RemoveAll(x => x.GetType() == typeof(BatteryTrait));

            Assert.AreEqual(1, traits.Count);

            var onOffTrait = traits.OfType<OnOffTrait>().FirstOrDefault();

            Assert.IsNotNull(onOffTrait);
            Assert.IsTrue(onOffTrait.IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(20)]
        [DataRow(29)]
        [DataRow(35)]
        [DataRow(37)]
        [DataRow(38)]
        [DataRow(39)]
        [DataRow(40)]
        [DataRow(44)]
        [DataRow(53)]
        [DataRow(54)]
        [DataRow(55)]
        [DataRow(91)]
        [DataRow(102)]
        [DataRow(113)]
        [DataRow(117)]
        public void TestSensorsTraits(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);
            traits.RemoveAll(x => x.GetType() == typeof(BatteryTrait));

            Assert.IsTrue(traits.All(x => x.GetType() == typeof(SensorTrait)), "All traits are of type sensor");

            var sensorTraits = traits.OfType<SensorTrait>();

            foreach (var sensorTrait in sensorTraits)
            {
                Assert.AreNotEqual(UnitType.Unknown, sensorTrait.Unit);
            }
        }

        [DataTestMethod]
        [DataRow(79)]
        [DataRow(80)]
        [DataRow(85)]
        [DataRow(86)]
        [DataRow(96)]
        [DataRow(97)]
        [DataRow(107)]
        [DataRow(108)]
        public void TestSetPointTraits(int idx)
        {
            var traits = GetParsedTraits((ulong)idx);
            traits.RemoveAll(x => x.GetType() == typeof(BatteryTrait));

            Assert.AreEqual(1, traits.Count);
            var setPointTrait = traits[0] as SetPointTrait;
            Assert.IsNotNull(setPointTrait);
        }

        private List<IDomoticzTrait> GetParsedTraits(ulong idx)
        {
            return _TestParsedTraits.Where(x => x.Idx == idx)
                .ToList();
        }
    }
}