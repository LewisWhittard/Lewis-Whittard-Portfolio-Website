﻿using SEO.Models.JsonLD;
using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.Video.Interface;

namespace UIFactory.Factory.Concrete.Video
{
    public class Video : IVideo
    {
        public Infrastructure.Models.Data.Video.Video VideoData { get; private set; }
        public List<JsonLDData>? JsonLDDatas { get; private set; }

        private readonly Infrastructure.Models.Data.Video.Video _video;
        private readonly JsonLDService? _jsonLDService;

        public Video(Infrastructure.Models.Data.Video.Video videoData, JsonLDService? jsonLDService)
        {
            _video = videoData;
            _jsonLDService = jsonLDService;
            VideoData = _video;
            SetJsonLD();
        }

        public void SetJsonLD()
        {
            if (_jsonLDService != null)
            {
                JsonLDDatas = _jsonLDService.GetBySuperClassGUID(_video.GUID, false);
            }
            else
            {
                JsonLDDatas = null;
            }
        }
    }
}