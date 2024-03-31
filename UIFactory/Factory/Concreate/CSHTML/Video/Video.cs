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
        private readonly Infrastructure.Models.Data.Video.Interfaces.IVideo _Video;

        public Video(Infrastructure.Models.Data.Video.Interfaces.IVideo video)
        {
            _Video = video;
            Title = _Video.Title;
            Description = _Video.Description;
            Navigation = _Video.Navigation;
            DisplayOrder = _Video.DisplayOrder;
            Source = _Video.Source;
        }
    }
}
