using Infrastructure.Models.Data.CarouselCard.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.CarouselCard
{
    public class CarouselCard : ICarouselCard, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
        [JsonIgnore]
        public UIConcreate? UIConcreateType { get; set; }
    }
}
