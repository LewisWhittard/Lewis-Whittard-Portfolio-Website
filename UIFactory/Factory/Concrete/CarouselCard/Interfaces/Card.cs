using UIFactory.Factory.Concrete.CarouselCard;

namespace UIFactory.Factory.Concrete.CarouselCard.Interfaces
{
    public interface ICard
    {
        Image Image { get; }
        string Title { get; }
        string Description { get; }
        string Navigation { get; }
        string Alt { get; }
    }
}
