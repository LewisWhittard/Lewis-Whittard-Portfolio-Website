namespace Infrastructure.Models.Data.CarouselCard.Interfaces
{
    public interface ICarouselCard
    {
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
    }
}
