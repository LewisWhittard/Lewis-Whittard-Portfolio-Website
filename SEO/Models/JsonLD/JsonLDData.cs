using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;

namespace SEO.Models.JsonLD
{
    public class JsonLDData : IJsonLDData, IData
    {
        public string? SuperClassGUID { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
        public string Page {  get; set; }
        public int Id { get; set; }
        public int? DisplayOrder { get; set; }
        public string GUID { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}
