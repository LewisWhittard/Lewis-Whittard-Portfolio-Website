using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Card.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Shared.Card
{
    public class Card : ICard, IData
    {
        public Image.Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int? DisplayOrder { get; set; }
        public string GUID { get; set; }
        public int PageId { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Card(Image.Image image, string title, string description, string navigation,int id,bool deleted,bool inactive,int displayOrder,string gUID, int pageId)
        {
            Image = image;
            Title = title;
            Description = description;
            Navigation = navigation;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            GUID = gUID;
            UIConcreteType = UIConcrete.Card;
            PageId = pageId;
        }

        public Card()
        {
            UIConcreteType = UIConcrete.Card;
        }
    }
}
