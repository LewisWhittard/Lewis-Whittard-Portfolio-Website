using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.CSHTML.Concrete.Video.Interfaces;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Video
{
    public class Video : ICSHTML, IVideo, IUI
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public int DisplayOrder { get; set; }
        public string Source { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private readonly Infrastructure.Models.Data.Video.Interfaces.IVideo _video;

        public Video(Infrastructure.Models.Data.Video.Interfaces.IVideo video)
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
