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
        public void ParseTraits(IReadOnlyList<DomoticzDeviceModel> models, ICollection<IDomoticzTrait> traits)
        {
            if (models is null)
                throw new System.ArgumentNullException(nameof(models));
            if (traits is null)
                throw new System.ArgumentNullException(nameof(traits));

            for (int modelI = 0; modelI < models.Count; ++modelI)
            {
                var model = models[modelI];
                for (int parserI = 0; parserI < _Parsers.Count; ++parserI)
                    _Parsers[parserI].ParseProperties(model, traits);
            }
        }

        #region Fields

        private List<ITraitParser> _Parsers = null;

        #endregion Fields

        #region Constructors

        public DomoticzDeviceParser()
        {
            var parserTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(ITraitParser).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract
                    && x.GetConstructors().Any(c => c.GetParameters().Length == 0));

            _Parsers = new List<ITraitParser>(parserTypes.Select(x => Activator.CreateInstance(x) as ITraitParser));
        }

        #endregion Constructors
    }
}
