using Infrastructure.Models.Data.Card.Interface;
using Infrastructure.Models.Data.Interface;

namespace Infrastructure.Models.Data.Card
{
    public class Card : ICard , IData
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int DisplayOrder { get; set; }
        public UIConcreate? UIConcreateType { get; set; }

        public Card()
        {

        }
    }
}
