using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;

namespace SEO.Models.JsonLD
{
    public class JsonLDData : IJsonLDData
    {
        public int SuperClassGUID { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
        public string Page {  get; set; }
    }
}
