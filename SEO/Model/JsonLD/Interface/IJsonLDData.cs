using Infrastructure.Models.Data.Interface;

namespace SEO.Model.JsonLD.Interface
{
    public interface IJsonLDData
    {
        string SuperClassUIID { get; }
        UIConcrete? UIConcreteType { get; }
        int? PageId { get; }
    }
}
