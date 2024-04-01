using UIFactory.Factory.CSHTML.Concreate.CarouselCard;

namespace UIFactory.Factory.CSHTML.Concreate.CarouselCard.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
    }
}
