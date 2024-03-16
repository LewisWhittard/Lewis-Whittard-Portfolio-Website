using UIFactory.Data.HTML.Carousel.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.Carousel
{
    public class Image : IImage, IData
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}
