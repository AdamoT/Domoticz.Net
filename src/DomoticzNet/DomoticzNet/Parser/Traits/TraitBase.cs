using DomoticzNet.Service.Models;

namespace DomoticzNet.Parser.Traits
{
    public class TraitBase : IDomoticzTrait
    {
        public ulong Id { get; }
        public DomoticzPropertyModel Model { get; }

        public TraitBase(DomoticzPropertyModel propertyModel)
        {
            Model = propertyModel ?? throw new System.ArgumentNullException(nameof(propertyModel));
            Id = propertyModel.Idx;
        }
    }
}
