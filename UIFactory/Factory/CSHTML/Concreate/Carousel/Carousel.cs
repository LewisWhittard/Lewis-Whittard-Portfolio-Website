using UIFactory.Factory.CSHTML.Concreate.Carousel.Interfaces;
using UIFactory.Factory.CSHTML.Concreate.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concreate.Carousel
{
    public class Carousel : ICarousel, ICSHTML, IJsonLD, IUI
    {
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public UI? UIType { get; set; }
        private readonly Infrastructure.Models.Data.Carousel.Carousel _carousel;

        public Carousel(Infrastructure.Models.Data.Carousel.Carousel carousel)
        {
            _carousel = carousel;
            foreach (var item in _carousel.Images)
            {
                Images.Add(new Image(item));
            }
            DisplayOrder = _carousel.DisplayOrder;
            UIType = UI.Carousel;
        }
    }
}
