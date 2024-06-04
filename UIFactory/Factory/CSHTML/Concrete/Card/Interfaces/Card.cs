namespace UIFactory.Factory.CSHTML.Concrete.Card.Interfaces
{
    public interface ICard
    {
        Image Image { get; }
        string Title { get; }
        string Description { get; }
        string Navigation { get; }
    }
}
