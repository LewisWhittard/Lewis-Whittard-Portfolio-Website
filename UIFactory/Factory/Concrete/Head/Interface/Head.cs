using SEO.Model.JsonLD;
using SEO.Model.Meta.Interface;

namespace UIFactory.Factory.Concrete.Head.Interface
{
    public interface IHead
    {
        Infrastructure.Models.Data.Head.Head HeadData { get; }
        List<MetaData> MetaDatas { get; }
        List<JsonLDData> jsonLDDatas { get; }
    }
}
