namespace UIFactory.Factory.Concrete.CarouselCard.Interface
{
    public interface ICarouselCard
    {
        Infrastructure.Models.Data.CarouselCard.CarouselCard CarouselCardData { get; }
        List<SEO.Model.JsonLD.JsonLDData> JsonLDDatas { get; }
    }
}
