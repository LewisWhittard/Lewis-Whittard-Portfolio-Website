using UIFactory.Data.HTML.CarouselCard.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.CarouselCard
{
    public class Paragraph : IData, IParagraph
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}
