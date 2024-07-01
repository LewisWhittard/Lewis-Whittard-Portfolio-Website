using SEO.Model.JsonLD;

namespace UIFactory.Factory.Concrete.Video.Interface
{
    public interface IVideo
    {
        Infrastructure.Models.Data.Video.Video VideoData { get; }
        List<JsonLDData>? JsonLDDatas { get; }
    }
}
