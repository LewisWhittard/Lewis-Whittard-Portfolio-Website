using UIFactory.Concreate.CSHTML.Interface;
using UIFactory.Concreate.CSHTML.Carousel;
using UIFactory.Concreate.CSHTML.CarouselCard;
using UIFactory.Concreate.CSHTML.InfomationBlock;
using UIFactory.Concreate.CSHTML.Table;
using Infrastructure.Models.Data.Interface;

namespace UIFactory.Factory.HTML
{
    class CSHTMLFactory<T>
    {
        // Factory method to create HMTL
        public IHTML CreateCSHMTL(IData type)
        {
            var value = CastFromIDataToClass(type);

            switch (value)
            {
                case nameof(Card):
                    return new Concreate.CSHTML.Card.Card();
                case nameof(Carousel):
                    return new Carousel();
                case nameof(CarouselCard):
                    return new CarouselCard();
                case nameof(InfomatonBlock):
                    return new InfomatonBlock();
                case nameof(Table):
                    return new Table();
                default:
                    throw new ArgumentException("Unknown type: " + type);
            }
        }

        public object CastFromIDataToClass(IData value)
        {
            var type = value.GetType();

            switch (type.Name)
            {
                case nameof(Infrastructure.Models.Data.Card.Card):
                    return (Infrastructure.Models.Data.Card.Card)value;
                case nameof(Infrastructure.Models.Data.Carousel.Carousel):
                    return (Infrastructure.Models.Data.Carousel.Carousel)value;
                case nameof(Infrastructure.Models.Data.CarouselCard.CarouselCard):
                    return (Infrastructure.Models.Data.CarouselCard.CarouselCard)value;
                case nameof(Infrastructure.Models.Data.InfomationBlock.InfomatonBlock):
                    return (Infrastructure.Models.Data.InfomationBlock.InfomatonBlock)value;
                case nameof(Infrastructure.Models.Data.Table.Table):
                    return(Table)value;
                default:
                    throw new ArgumentException("Unknown type: " + type);
            }
        }
    }
}