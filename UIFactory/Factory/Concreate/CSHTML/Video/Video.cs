using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concreate.CSHTML.Interface;
using UIFactory.Factory.Concreate.CSHTML.Video.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.Video
{
    public class Video : ICSHTML, IVideo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public int DisplayOrder { get; set; }
        public string Source { get; set; }
        public UIPartial? UIPartialType { get; set; }
        private readonly Infrastructure.Models.Data.Video.Interfaces.IVideo _video;

        public Video(Infrastructure.Models.Data.Video.Interfaces.IVideo video)
        {
            _video = video;
            Title = _video.Title;
            Description = _video.Description;
            Navigation = _video.Navigation;
            DisplayOrder = _video.DisplayOrder;
            Source = _video.Source;
            UIPartialType = UIPartial.Video;
        }
    }
}
