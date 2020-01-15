using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public interface IDomoticzTrait
    {
        int Idx { get; }
        DomoticzDeviceModel SourceModel { get; }
    }
}
