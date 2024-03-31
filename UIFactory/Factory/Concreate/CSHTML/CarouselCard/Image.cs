using UIFactory.Factory.Concreate.CSHTML.CarouselCard.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.CarouselCard
{
    public class Image : IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        private readonly Infrastructure.Models.Data.CarouselCard.Image _Image;


        public Image(Infrastructure.Models.Data.CarouselCard.Image image)
        {
            _Image = image;
            Source = _Image.Source;
            DisplayOrder = _Image.DisplayOrder;
            Id = _Image.Id;
        }
    }
}
