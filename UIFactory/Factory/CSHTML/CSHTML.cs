using UIFactory.Factory.Concreate.CSHTML.Carousel;
using UIFactory.Factory.Concreate.CSHTML.CarouselCard;
using UIFactory.Factory.Concreate.CSHTML.InfomationBlock;
using UIFactory.Factory.Concreate.CSHTML.Table;
using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.CSHTML.Interface;
using UIFactory.Factory.Concreate.CSHTML.Interface;
using UIFactory.Factory.Concreate.CSHTML.Video;
namespace UIFactory.Factory.CSHTML
{
    class CSHTML : IFactory
    {
        public ICSHTML CreateCSHMTL(IData data)
        {

            switch (data.UIConcreateType)
            {
                case UIConcreate.Card:
                    var card = (Infrastructure.Models.Data.Card.Card) data;
                    return new Concreate.CSHTML.Card.Card(card);
                case UIConcreate.Carousel:
                    var carousel = (Infrastructure.Models.Data.Carousel.Carousel)data;
                    return new Carousel(carousel);
                case UIConcreate.CarouselCard:
                    var carouselCard = (Infrastructure.Models.Data.CarouselCard.CarouselCard)data;
                    return new CarouselCard(carouselCard);
                case UIConcreate.InfomationBlock:
                    var infomationBlock = (Infrastructure.Models.Data.InfomationBlock.InfomatonBlock)data;
                    return new InfomatonBlock(infomationBlock);
                case UIConcreate.Table:
                    var table = (Infrastructure.Models.Data.Table.Table)data;
                    return new Table(table);
                case UIConcreate.Video:
                    var video = (Infrastructure.Models.Data.Video.Video)data;
                    return new Video(video);
                default:
                    throw new ArgumentException("Unknown type: " + data);
            }
        }
    }
}