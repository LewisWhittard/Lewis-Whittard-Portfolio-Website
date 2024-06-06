using SEO.Models.Alt.Interface;
using UIFactory.Factory.Concrete.Carousel.Interfaces;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.Concrete.Carousel
{
    public class Image : IImage, IUI
    {
        public string Source { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string alt { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }

        private readonly Infrastructure.Models.Data.Shared.Image.Image _image;
        private readonly IAltData _alt;

        public Image(Infrastructure.Models.Data.Shared.Image.Image image, IAltData altData)
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
