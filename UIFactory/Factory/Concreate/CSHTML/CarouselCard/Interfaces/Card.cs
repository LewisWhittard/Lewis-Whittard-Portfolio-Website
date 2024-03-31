using UIFactory.Factory.Concreate.CSHTML.CarouselCard;

namespace UIFactory.Factory.Concreate.CSHTML.CarouselCard.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
    }
}
