namespace Infrastructure.Models.Data.CarouselCard.Interfaces
{
    public interface ICarouselCard
    {
        List<Shared.Card.Card> Cards { get; }
        int PageId { get; }
    }
}
