using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public class TraitBase : IDomoticzTrait
    {
        public ulong Id { get; }
        public DomoticzDeviceModel SourceModel { get; }

        public TraitBase(DomoticzDeviceModel propertyModel)
        {
            SourceModel = propertyModel ?? throw new System.ArgumentNullException(nameof(propertyModel));
            Id = propertyModel.Idx;
        }

        public override string ToString() => $"{this.GetType().Name} - {SourceModel.Name}";
    }
}
