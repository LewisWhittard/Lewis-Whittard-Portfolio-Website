using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;

namespace SEO.Models.JsonLD
{
    public class JsonLDData : IJsonLDData
    {
        public int SuperClassDataId { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
        public string Page {  get; set; }
    }
}
