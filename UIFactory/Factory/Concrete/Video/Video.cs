using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Video.Interfaces;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.Concrete.Video
{
    public class Video : ICSHTML, IVideo, IUI
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Navigation { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string Source { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }

        private readonly Infrastructure.Models.Data.Video.Video _video;

        public Video(Infrastructure.Models.Data.Video.Video video)
        {
            _video = video;
            Title = _video.Title;
            Description = _video.Description;
            Navigation = _video.Navigation;
            DisplayOrder = _video.DisplayOrder;
            Source = _video.Source;
            UIType = UI.Video;
            GUID = _video.GUID;
        }
    }
}
