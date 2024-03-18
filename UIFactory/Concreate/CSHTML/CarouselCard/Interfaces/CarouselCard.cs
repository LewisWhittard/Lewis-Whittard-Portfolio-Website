namespace UIFactory.Concreate.CSHTML.CarouselCard.Interfaces
{
    public interface ICarouselCard
    {
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
    }
}
