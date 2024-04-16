using Infrastructure.Models.Data.Interface;

namespace SEO.Models.Meta.Interface
{
    public class Meta : IMeta, IData
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public string Content { get; set; }
        public string GUID { get; set; }
        public string? Charset { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
    }
}
