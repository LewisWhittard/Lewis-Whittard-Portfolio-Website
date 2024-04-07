using SEO.Models.Alt.Interface;
using UIFactory.Factory.CSHTML.Concrete.Carousel.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Carousel
{
    public class Image : IImage, IUI
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public string alt { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private readonly Infrastructure.Models.Data.Carousel.Image _image;
        private readonly IAltData _alt;

        public Image(Infrastructure.Models.Data.Carousel.Image image, IAltData altData)
        {
            _image = image;
            _alt = altData;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            alt = _alt.Value;
            GUID = _image.GUID;
        }

    }
}
