using Infrastructure.Models.Data.Interface;

namespace SEO.Model.JsonLD.Interface
{
    public interface IJsonLDData
    {
        UIConcrete? UIConcreteType { get; }
        int? PageId { get; }
    }
}
