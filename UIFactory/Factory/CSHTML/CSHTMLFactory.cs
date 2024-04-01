using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.CSHTML.Interface;
using UIFactory.Factory.CSHTML.Concreate.Carousel;
using UIFactory.Factory.CSHTML.Concreate.CarouselCard;
using UIFactory.Factory.CSHTML.Concreate.InfomationBlock;
using UIFactory.Factory.CSHTML.Concreate.Table;
using UIFactory.Factory.CSHTML.Concreate.Video;
using UIFactory.Factory.Interface;
namespace UIFactory.Factory.CSHTML
{
    class CSHTMLFactory : IUIFactory
    {
        public IUI CreateUI(IData data)
        {

            switch (data.UIConcreateType)
            {
                case UIConcreate.Card:
                    var card = (Infrastructure.Models.Data.Card.Card) data;
                    return new Concreate.Card.Card(card);
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