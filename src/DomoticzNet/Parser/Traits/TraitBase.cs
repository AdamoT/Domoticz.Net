using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public class TraitBase : IDomoticzTrait
    {
        public int Idx { get; }
        public DomoticzDeviceModel SourceModel { get; }

        public TraitBase(DomoticzDeviceModel propertyModel)
        {
            SourceModel = propertyModel ?? throw new System.ArgumentNullException(nameof(propertyModel));
            Idx = propertyModel.Idx;
        }

        public override string ToString() => $"{SourceModel.Name} [{this.GetType().Name}] ({SourceModel.Idx})";
    }
}
