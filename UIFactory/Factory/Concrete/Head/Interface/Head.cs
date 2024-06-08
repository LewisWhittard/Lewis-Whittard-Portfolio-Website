using SEO.Models.JsonLD;
using SEO.Models.Meta.Interface;

namespace UIFactory.Factory.Concrete.Head.Interface
{
    public interface IHead
    {
        Infrastructure.Models.Data.Head.Head HeadData { get; }
        MetaData MetaData { get; }
        List<JsonLDData> jsonLDDatas { get; }
    }
}
