using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Interfaces.CarouselCard.Interfaces;

namespace Infrastructure.Models.Data.CarouselCard
{
    public class Card : ICard, IData
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}
