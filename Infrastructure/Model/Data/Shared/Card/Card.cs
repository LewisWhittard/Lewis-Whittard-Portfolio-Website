using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Card.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Shared.Card
{
    public class Card : ICard, IData
    {
        public Image.Image Image { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Navigation { get; private set; }
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string UIID { get; private set; }
        public int? PageId { get; private set; }
        public int? CarouselCardId { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }

        public Card(Image.Image image, string title, string description, string navigation, int id, bool deleted, bool inactive, int displayOrder, string uIId, int? pageId, int? carouselCardId)
        {
            Image = image;
            Title = title;
            Description = description;
            Navigation = navigation;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            UIID = uIId;
            UIConcreteType = UIConcrete.Card;
            PageId = pageId;
            CarouselCardId = carouselCardId;

        }

        public Card()
        {
            UIConcreteType = UIConcrete.Card;
        }
    }
}
