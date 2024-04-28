using Infrastructure.Models.Data.Interface;
using SEO.Models.Alt.Interface;

namespace SEO.Models.Alt
{
    public class AltData : IAltData, IData
    {
        public string SuperClassGUID { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
        public string Page { get; set; }
        public int? DisplayOrder { get; set; }
        public string Value { get; set; }
        public string GUID { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}
