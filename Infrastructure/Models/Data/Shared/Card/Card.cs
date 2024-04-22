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
        public int DisplayOrder { get; set; }
        public string GUID { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Card()
        {
            UIConcreteType = UIConcrete.Card;
        }
    }
}
