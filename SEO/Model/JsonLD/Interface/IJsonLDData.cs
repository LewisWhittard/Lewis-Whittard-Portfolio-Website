using Infrastructure.Models.Data.Interface;

namespace SEO.Model.JsonLD.Interface
{
    public interface IJsonLDData
    {
        string UIId { get; }
        UIConcrete? UIConcreteType { get; }
        int? PageId { get; }
    }
}
