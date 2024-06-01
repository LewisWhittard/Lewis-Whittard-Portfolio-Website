namespace Infrastructure.Models.Data.CarouselCard.Interfaces
{
    public interface ICarouselCard
    {
        public List<Shared.Card.Card> Cards { get; set; }
        public int PageId { get; set; }

    }
}
