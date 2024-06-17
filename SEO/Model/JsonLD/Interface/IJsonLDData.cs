using Infrastructure.Models.Data.Interface;

namespace SEO.Model.JsonLD.Interface
{
    public interface IJsonLDData
    {
        string SuperClassGUID { get; }
        UIConcrete? UIConcreteType { get; }
    }
}
