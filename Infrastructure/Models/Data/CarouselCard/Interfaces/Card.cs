using Infrastructure.Models.Data.Card;

namespace Infrastructure.Models.Data.CarouselCard.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
    }
}
