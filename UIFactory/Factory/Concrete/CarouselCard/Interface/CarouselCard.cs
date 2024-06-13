﻿namespace UIFactory.Factory.Concrete.CarouselCard.Interface
{
    public interface ICarouselCard
    {
        Infrastructure.Models.Data.CarouselCard.CarouselCard CarouselCardDatas { get; }
        List<SEO.Models.JsonLD.JsonLDData> JsonLDData { get; }
    }
}
