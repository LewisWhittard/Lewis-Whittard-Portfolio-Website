using UIFactory.Factory.Concreate.CSHTML.CarouselCard.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.CarouselCard
{
    public class Image : IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }

        public Image(Infrastructure.Models.Data.CarouselCard.Image image)
        {
            Source = image.Source;
            DisplayOrder = image.DisplayOrder;
            Id = image.Id;
        }
    }
}
