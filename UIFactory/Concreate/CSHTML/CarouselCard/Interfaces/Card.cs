using UIFactory.Concreate.CSHTML.CarouselCard;

namespace UIFactory.Concreate.CSHTML.CarouselCard.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
    }
}
