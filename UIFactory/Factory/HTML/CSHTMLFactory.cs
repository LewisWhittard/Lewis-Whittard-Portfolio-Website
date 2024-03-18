using UIFactory.Concreate.CSHTML.Interface;
using UIFactory.Concreate.CSHTML.Carousel;
using UIFactory.Concreate.CSHTML.CarouselCard;
using UIFactory.Concreate.CSHTML.InfomationBlock;
using UIFactory.Concreate.CSHTML.Table;

namespace UIFactory.Factory.HTML
{
    class CSHTMLFactory
    {
        // Factory method to create HMTL
        public IHTML CreateCSHMTL(IHTML type)
        {
            switch (type.Name)
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
        }
    }
}