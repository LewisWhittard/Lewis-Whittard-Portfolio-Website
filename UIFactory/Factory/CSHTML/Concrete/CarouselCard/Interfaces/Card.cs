using UIFactory.Factory.CSHTML.Concrete.CarouselCard;

namespace UIFactory.Factory.CSHTML.Concrete.CarouselCard.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
    }
}
