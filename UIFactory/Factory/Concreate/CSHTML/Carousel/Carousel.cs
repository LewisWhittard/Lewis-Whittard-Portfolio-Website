using UIFactory.Factory.Concreate.CSHTML.Carousel.Interfaces;
using UIFactory.Factory.Concreate.CSHTML.Interface;

namespace UIFactory.Factory.Concreate.CSHTML.Carousel
{
    public class Carousel : ICarousel, ICSHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        private readonly Infrastructure.Models.Data.Carousel.Carousel _carousel;

        public Carousel(Infrastructure.Models.Data.Carousel.Carousel carousel)
        {
            _carousel = carousel;
            Id = _carousel.Id;
            foreach (var item in _carousel.Images)
            {
                Images.Add(new Image(item));
            }
            DisplayOrder = _carousel.DisplayOrder;
        }
    }
}
