using UIFactory.Factory.CSHTML.Concrete.CarouselCard.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.CarouselCard
{
    public class Image : IImage, IUI
    {
        public string Source { get; set; }
        public int? DisplayOrder { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private readonly Infrastructure.Models.Data.CarouselCard.Image _image;


        public Image(Infrastructure.Models.Data.CarouselCard.Image image)
        {
            _image = image;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            GUID = _image.GUID;

        }

        public Image()
        {
            Source = "PlaceHolderImage";
            GUID = "PlaceholderImage";
        }
    }
}
