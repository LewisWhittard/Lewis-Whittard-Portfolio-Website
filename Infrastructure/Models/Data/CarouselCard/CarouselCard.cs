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
        public List<Shared.Card.Card> Cards { get; set; }
        public int? DisplayOrder { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }
        public string GUID { get; set; }

        public CarouselCard(int id, bool deleted, bool inactive, List<Shared.Card.Card> cards, int? displayOrder, string gUID)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Cards = cards;
            DisplayOrder = displayOrder;
            GUID = gUID;
            UIConcreteType = UIConcrete.CarouselCard;
        }
    }
}
