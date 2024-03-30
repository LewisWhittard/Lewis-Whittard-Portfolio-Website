using UIFactory.Concreate.CSHTML.Carousel.Interfaces;
using UIFactory.Concreate.CSHTML.Interface;

namespace UIFactory.Concreate.CSHTML.Carousel
{
    public class Carousel : ICarousel, ICSHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }

        public Carousel()
        {
            
        }

        public Carousel(Infrastructure.Models.Data.Carousel.Carousel carousel)
        {
            Id = carousel.Id;
            foreach (var item in carousel.Images) 
            {
                Images.Add(new Image(item));
            }
            DisplayOrder = carousel.DisplayOrder;
        }
    }
}
