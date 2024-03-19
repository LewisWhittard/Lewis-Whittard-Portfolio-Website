using UIFactory.Concreate.CSHTML.Carousel.Interfaces;

namespace UIFactory.Concreate.CSHTML.Carousel
{
    public class Image : IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }

        public Image(Infrastructure.Models.Data.Carousel.Image image)
        {
            Source = image.Source;
            DisplayOrder = image.DisplayOrder;
            Id = image.Id;
        }

    }
}
