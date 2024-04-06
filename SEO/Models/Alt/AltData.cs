using Infrastructure.Models.Data.Interface;
using SEO.Models.Alt.Interface;

namespace SEO.Models.Alt
{
    public class AltData : IAltData
    {
        public int DataId { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
        public string Page { get; set; }
    }
}
