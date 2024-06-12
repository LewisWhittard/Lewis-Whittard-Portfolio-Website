using SEO.Models.JsonLD;
using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.Video.Interface;

namespace UIFactory.Factory.Concrete.Video
{
    public class Video : IVideo
    {
        public Infrastructure.Models.Data.Video.Video VideoData { get; }
        public List<JsonLDData> JsonLDDatas { get; }

        private readonly Infrastructure.Models.Data.Video.Video _video;
        private readonly JsonLDService _jsonLDDatas;

        public Video(Infrastructure.Models.Data.Video.Video videoData, JsonLDService jsonLDService)
        {
            _video = videoData;
            _jsonLDDatas = jsonLDService;
            VideoData = _video;
            JsonLDDatas = _jsonLDDatas.GetBySuperClassGUID(_video.GUID,false);
        }
    }
}
