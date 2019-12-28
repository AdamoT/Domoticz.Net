namespace DomoticzNet.Parser.Properties
{
    public class PropertyBase : IDomoticzProperty
    {
        public ulong Id { get; }

        public PropertyBase(ulong id)
        {
            Id = id;
        }
    }
}
