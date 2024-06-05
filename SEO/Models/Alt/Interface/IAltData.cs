using Infrastructure.Models.Data.Interface;

namespace SEO.Models.Alt.Interface
{
    public interface IAltData
    {
        string SuperClassGUID { get; }
        UIConcrete? UIConcreteType { get; }
        string Value { get; }
        string GUID { get; }
    }
}
