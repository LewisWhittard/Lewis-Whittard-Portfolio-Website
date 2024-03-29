using Infrastructure.Models.Data.CarouselCard.Interfaces;
using Infrastructure.Models.Data.Interface;

namespace Infrastructure.Models.Data.CarouselCard
{
    public class CarouselCard : ICarouselCard, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
        public UIConcreate? UIConcreate { get; set; }
    }
}
