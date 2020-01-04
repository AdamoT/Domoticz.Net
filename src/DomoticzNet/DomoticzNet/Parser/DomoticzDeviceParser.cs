using DomoticzNet.Models;
using DomoticzNet.Parser.Parsers;
using DomoticzNet.Parser.Traits;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DomoticzNet.Parser
{
    public class DomoticzDeviceParser
    {
        public void ParseTraits(IReadOnlyList<DomoticzDeviceModel> models, ICollection<IDomoticzTrait> traits, ICollection<DomoticzDeviceModel> unusedOrFailedDevices = null)
        {
            if (models is null)
                throw new System.ArgumentNullException(nameof(models));
            if (traits is null)
                throw new System.ArgumentNullException(nameof(traits));

            for (int modelI = 0; modelI < models.Count; ++modelI)
            {
                var model = models[modelI];
                int startTraitsCount = traits.Count;
                for (int parserI = 0; parserI < Parsers.Count; ++parserI)
                {
                    try
                    {
                        Parsers[parserI].ParseProperties(model, traits);
                    }
#pragma warning disable CA1031 // Do not catch general exception types
                    catch
#pragma warning restore CA1031 // Do not catch general exception types
                    {
                        unusedOrFailedDevices?.Add(model);
                    }
                }

                if (traits.Count == startTraitsCount)
                {//No trait added for this model
                    unusedOrFailedDevices?.Add(model);
                }
            }
        }

        #region Properties

        public List<ITraitParser> Parsers { get; private set; }

        #endregion Properties

        #region Constructors

        public DomoticzDeviceParser()
        {
            var parserTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(ITraitParser).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract
                    && x.GetConstructors().Any(c => c.GetParameters().Length == 0));

            Parsers = new List<ITraitParser>(parserTypes.Select(x => Activator.CreateInstance(x) as ITraitParser));
        }

        #endregion Constructors
    }
}
