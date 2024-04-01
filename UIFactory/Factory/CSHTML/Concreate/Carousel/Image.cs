using System.Net.Http.Headers;
using UIFactory.Factory.CSHTML.Concreate.Carousel.Interfaces;

namespace UIFactory.Factory.CSHTML.Concreate.Carousel
{
    public class Image : IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        private readonly Infrastructure.Models.Data.Carousel.Image _image;

        public Image(Infrastructure.Models.Data.Carousel.Image image)
        {
            Source = image.Source;
            DisplayOrder = image.DisplayOrder;
            _image = image;
        }

    }
}
