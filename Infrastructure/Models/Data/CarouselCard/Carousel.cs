using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Interfaces.CarouselCard.Interfaces;

namespace Infrastructure.Models.Data.CarouselCard
{
    public class CarouselCard : ICarouselCard, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Card> Images { get; set; }
    }
}
