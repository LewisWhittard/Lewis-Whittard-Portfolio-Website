using Infrastructure.Models.Data.CarouselCard.Interfaces;
using Infrastructure.Models.Data.Interface;

namespace Infrastructure.Models.Data.CarouselCard
{
    public class Paragraph : IData, IParagraph
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public UIConcreate? UIConcreate { get; set; }
    }
}
