using Infrastructure.Models.Data.CarouselCard.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.CarouselCard
{
    public class CarouselCard : ICarouselCard, IData
    {
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public List<Shared.Card.Card> Cards { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int PageId { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }
        public string GUID { get; private set; }

        public CarouselCard()
        {
            UIConcreteType = UIConcrete.CarouselCard;
        }

        public CarouselCard(int id, bool deleted, bool inactive, List<Shared.Card.Card> cards, int? displayOrder, string gUID, int pageId)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Cards = cards;
            DisplayOrder = displayOrder;
            GUID = gUID;
            UIConcreteType = UIConcrete.CarouselCard;
            PageId = pageId;
        }
    }
}
