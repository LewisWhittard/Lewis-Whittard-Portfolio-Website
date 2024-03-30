using UIFactory.Concreate.CSHTML.Interface;
using UIFactory.Concreate.CSHTML.Carousel;
using UIFactory.Concreate.CSHTML.CarouselCard;
using UIFactory.Concreate.CSHTML.InfomationBlock;
using UIFactory.Concreate.CSHTML.Table;
using Infrastructure.Models.Data.Interface;

namespace UIFactory.Factory.HTML
{
    class CSHTMLFactory
    {
        public IHTML CreateCSHMTL(IData type)
        {

            switch (type.UIConcreate)
            {
                case UIConcreate.Card:
                    return new Concreate.CSHTML.Card.Card();
                case UIConcreate.Carousel:
                    return new Carousel();
                case UIConcreate.CarouselCard:
                    return new CarouselCard();
                case UIConcreate.InfomationBlock:
                    return new InfomatonBlock();
                case UIConcreate.Table:
                    return new Table();
                default:
                    throw new ArgumentException("Unknown type: " + type);
            }

            return null;

        }
    }
}