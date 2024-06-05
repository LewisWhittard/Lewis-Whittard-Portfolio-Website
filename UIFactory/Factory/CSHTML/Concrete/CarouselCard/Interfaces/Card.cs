namespace UIFactory.Factory.CSHTML.Concrete.CarouselCard.Interfaces
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
