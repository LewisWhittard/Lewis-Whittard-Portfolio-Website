using Infrastructure.Models.Data.Interface;

namespace SEO.Models.JsonLD.Interface
{
    public interface IJsonLDData
    {
        string SuperClassGUID { get; }
        UIConcrete? UIConcreteType { get; }
        string Page { get; }
    }
}
