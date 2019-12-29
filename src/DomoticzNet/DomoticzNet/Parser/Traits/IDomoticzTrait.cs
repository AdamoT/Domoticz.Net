using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public interface IDomoticzTrait
    {
        ulong Id { get; }
        DomoticzDeviceModel SourceModel { get; }
    }
}
