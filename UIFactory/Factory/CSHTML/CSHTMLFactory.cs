using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.CSHTML.Concrete.Carousel;
using UIFactory.Factory.CSHTML.Concrete.CarouselCard;
using UIFactory.Factory.CSHTML.Concrete.InformationBlock;
using UIFactory.Factory.CSHTML.Concrete.Table;
using UIFactory.Factory.CSHTML.Concrete.Video;
using UIFactory.Factory.Interface;
using SEO.Models.JsonLD.Interface;
using Infrastructure.Service.Page.Interface;
using SEO.Service.JsonLDService.Interface;
using SEO.Service.AltService.Interface;
using SEO.Models.Alt.Interface;
using SEO.Service.MetaService.Interface;
using SEO.Models.Meta.Interface;

namespace UIFactory.Factory.CSHTML
{
    public class CSHTMLFactory : IUIFactory
    {
        private readonly IPageService _pageService;
        private readonly IJsonLDService _jsonLDService;
        private readonly IAltService _altService;
        private readonly IMetaService _metaService;

        public CSHTMLFactory(IPageService pageService, IJsonLDService jsonLDService, IAltService altService, IMetaService metaService)
        {
            _pageService = pageService;
            _jsonLDService = jsonLDService;
            _altService = altService;
            _metaService = metaService;
        }

        public List<IUI> CreateUIListByPageName(string PageName)
        {
            List<IUI> result = new List<IUI>();
            var pageData = _pageService.GetByPageNameAsIDataList(PageName,false);
            List<IMetaData> meta = _metaService.GetByPageName(PageName);
            foreach (var data in pageData)
            {
                List<IJsonLDData> jsonLD = _jsonLDService.GetBySuperClassGUID(data);
                List<IAltData> alt = _altService.GetBySuperClassGUID(data.GUID,false);
                var uI = CreateUI(data, jsonLD, alt, meta);
                result.Add(uI);
            }
            return result;
        }

        private IUI CreateUI(IData data, List<IJsonLDData> jsonLDData, List<IAltData> altData, List<IMetaData> meta)
        {
            switch (data.UIConcreteType)
            {
                case UIConcrete.Card:
                    var card = (Infrastructure.Models.Data.Shared.Card.Card)data;
                    return new Concrete.Card.Card(card, jsonLDData, altData);
                case UIConcrete.Carousel:
                    var carousel = (Infrastructure.Models.Data.Carousel.Carousel)data;
                    return new Carousel(carousel, jsonLDData, altData);
                case UIConcrete.CarouselCard:
                    var carouselCard = (Infrastructure.Models.Data.CarouselCard.CarouselCard)data;
                    return new CarouselCard(carouselCard,jsonLDData,altData);
                case UIConcrete.InformationBlock:
                    var informationBlock = (Infrastructure.Models.Data.InformationBlock.InfomatonBlock)data;
                    return new InfomatonBlock(informationBlock,jsonLDData,altData);
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