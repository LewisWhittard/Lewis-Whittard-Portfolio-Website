using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.CSHTML.Concrete.Carousel;
using UIFactory.Factory.CSHTML.Concrete.CarouselCard;
using UIFactory.Factory.CSHTML.Concrete.InfomationBlock;
using UIFactory.Factory.CSHTML.Concrete.Table;
using UIFactory.Factory.CSHTML.Concrete.Video;
using UIFactory.Factory.Interface;
using SEO.Models.JsonLD.Interface;
using Infrastructure.Service.Page.Interface;
using SEO.JsonLDService.Interface;

namespace UIFactory.Factory.CSHTML
{
    class CSHTMLFactory : IUIFactory
    {
        private readonly IPageService _pageService;
        private readonly IJsonLDService _jsonLDService;

        public CSHTMLFactory(IPageService pageService, IJsonLDService jsonLDService)
        {
            _pageService = pageService;
            _jsonLDService = jsonLDService;
        }

        public List<IUI> CreateUIList(string PageName)
        {
            List<IUI> result = new List<IUI>();
            var pageData = _pageService.Get(PageName).CreateIDataList();
            var PagejsonLDData = _jsonLDService.Get(PageName);
            foreach (var item in pageData)
            {
                List<IJsonLDData> jsonLD = PagejsonLDData.Where(x => x.DataId == item.Id && item.UIConcreteType == x.UIConcreteType).ToList();
                var uI = CreateUI(item,jsonLD);
                result.Add(uI);
            }
            return result;
        }

        private IUI CreateUI(IData data, List<IJsonLDData> jsonLDData)
        {
            switch (data.UIConcreteType)
            {
                case UIConcrete.Card:
                    var card = (Infrastructure.Models.Data.Card.Card)data;
                    return new Concrete.Card.Card(card);
                case UIConcrete.Carousel:
                    var carousel = (Infrastructure.Models.Data.Carousel.Carousel)data;
                    return new Carousel(carousel);
                case UIConcrete.CarouselCard:
                    var carouselCard = (Infrastructure.Models.Data.CarouselCard.CarouselCard)data;
                    return new CarouselCard(carouselCard);
                case UIConcrete.InfomationBlock:
                    var infomationBlock = (Infrastructure.Models.Data.InfomationBlock.InfomatonBlock)data;
                    return new InfomatonBlock(infomationBlock);
                case UIConcrete.Table:
                    var table = (Infrastructure.Models.Data.Table.Table)data;
                    return new Table(table);
                case UIConcrete.Video:
                    var video = (Infrastructure.Models.Data.Video.Video)data;
                    return new Video(video);
                default:
                    throw new ArgumentException("Unknown type: " + data);
            }
        }
    }
}