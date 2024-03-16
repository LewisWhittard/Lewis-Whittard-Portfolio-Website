using UIFactory.Data.HTML.CarouselCard;

namespace UIFactory.Data.HTML.CarouselCard.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
    }
}
