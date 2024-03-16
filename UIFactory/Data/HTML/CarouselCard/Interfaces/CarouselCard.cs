namespace UIFactory.Data.HTML.CarouselCard.Interfaces
{
    public interface ICarouselCard
    {
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
    }
}
