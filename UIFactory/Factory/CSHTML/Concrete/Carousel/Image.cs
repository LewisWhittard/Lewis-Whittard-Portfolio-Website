using SEO.Models.Alt.Interface;
using UIFactory.Factory.CSHTML.Concrete.Carousel.Interfaces;

namespace UIFactory.Factory.CSHTML.Concrete.Carousel
{
    public class Image : IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public string alt { get; set; }
        private readonly Infrastructure.Models.Data.Carousel.Image _image;
        private readonly IAltData _alt;

        public Image(Infrastructure.Models.Data.Carousel.Image image, IAltData altData)
        {
            _image = image;
            _alt = altData;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            alt = _alt.Value;
            
        }

    }
}
