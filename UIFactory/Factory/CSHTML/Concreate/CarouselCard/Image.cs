using UIFactory.Factory.CSHTML.Concreate.CarouselCard.Interfaces;

namespace UIFactory.Factory.CSHTML.Concreate.CarouselCard
{
    public class Image : IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        private readonly Infrastructure.Models.Data.CarouselCard.Image _image;


        public Image(Infrastructure.Models.Data.CarouselCard.Image image)
        {
            _image = image;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
        }
    }
}
