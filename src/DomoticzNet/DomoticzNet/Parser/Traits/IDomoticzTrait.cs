using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public interface IDomoticzTrait
    {
        ulong Idx { get; }
        DomoticzDeviceModel SourceModel { get; }
    }
}
