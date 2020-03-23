using System;
using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
	public class TraitBase : IDomoticzTrait
	{
		public TraitBase(DomoticzDeviceModel propertyModel)
		{
			SourceModel = propertyModel ?? throw new ArgumentNullException(nameof(propertyModel));
			Idx = propertyModel.Idx;
		}

		public int Idx { get; }
		public DomoticzDeviceModel SourceModel { get; }

		public override string ToString()
		{
			return $"{SourceModel.Name} [{GetType().Name}] ({SourceModel.Idx})";
		}
	}
}