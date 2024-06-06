using UIFactory.Factory.Concrete.Card;

namespace UIFactory.Factory.Concrete.Card.Interfaces
{
    public interface ICard
    {
        Image Image { get; }
        string Title { get; }
        string Description { get; }
        string Navigation { get; }
    }
}
