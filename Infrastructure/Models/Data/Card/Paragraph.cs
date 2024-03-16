using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Interfaces.Card;

namespace Infrastructure.Models.Data.Card
{
    public class Paragraph : IData, IParagraph
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}
