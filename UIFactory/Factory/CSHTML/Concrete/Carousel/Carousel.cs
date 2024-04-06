using SEO.Models.Alt.Interface;
using SEO.Models.JsonLD.Interface;
using UIFactory.Factory.CSHTML.Concrete.Carousel.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Carousel
{
    public class Carousel : ICarousel, ICSHTML, IJsonLD, IUI
    {
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public UI? UIType { get; set; }
        private readonly Infrastructure.Models.Data.Carousel.Carousel _carousel;
        private readonly List<IAltData> _alt;

        public Carousel(Infrastructure.Models.Data.Carousel.Carousel carousel, List<IJsonLDData> jsonLD, List<IAltData> alt)
        {
            _carousel = carousel;
            _alt = alt;
            foreach (var item in _carousel.Images)
            {
                Images.Add(new Image(item, _alt.Where(x => x.DisplayOrder == item.DisplayOrder).FirstOrDefault()));
            }
            DisplayOrder = _carousel.DisplayOrder;
            UIType = UI.Carousel;
        }
    }
}
