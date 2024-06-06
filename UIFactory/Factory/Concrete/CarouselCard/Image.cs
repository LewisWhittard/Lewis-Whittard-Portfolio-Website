using UIFactory.Factory.Concrete.CarouselCard.Interfaces;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.Concrete.CarouselCard
{
    public class Image : IImage, IUI
    {
        public string Source { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }
        public string Alt { get; private set; }

        private readonly Infrastructure.Models.Data.Shared.Image.Image _image;


        public Image(Infrastructure.Models.Data.Shared.Image.Image image)
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
            Alt = "PlaceHolder";
        }
    }
}
