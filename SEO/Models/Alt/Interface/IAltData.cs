using Infrastructure.Models.Data.Interface;

namespace SEO.Models.Alt.Interface
{
    public interface IAltData
    {
        public string SuperClassGUID { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
        public string Page { get; set; }
        public int DisplayOrder { get; set; }
        public string Value { get; set; }
        public string GUID { get; set; }
    }
}
