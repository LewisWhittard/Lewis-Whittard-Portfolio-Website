using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Interface;
using Infrastructure.Service.Page.Interface;
using SEO.Service.JsonLDService.Interface;
using SEO.Service.AltService.Interface;
using SEO.Service.MetaService.Interface;
using Infrastructure.Models.Data.Page;
using UIFactory.Factory.Concrete.Interface;
using Infrastructure.Models.Data.Head;
using SEO.Service.MetaService;
using SEO.Service.JsonLDService;
using Infrastructure.Models.Data.Shared.Card;
using SEO.Service.AltService;
using Infrastructure.Models.Data.Carousel;
using Infrastructure.Models.Data.CarouselCard;
using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Table;
using Infrastructure.Models.Data.Video;

namespace UIFactory.Factory.CSHTML
{
    public class CSHTMLFactory : IUIFactory
    {
        private readonly IPageService _pageService;
        private readonly IJsonLDService? _jsonLDService;
        private readonly IAltService? _altService;
        private readonly IMetaService? _metaService;

        public CSHTMLFactory(IPageService pageService, IJsonLDService? jsonLDService, IAltService? altService, IMetaService? metaService)
        {
            _pageService = pageService;
            _jsonLDService = jsonLDService;
            _altService = altService;
            _metaService = metaService;
        }

        public List<IConcreteUI> CreateConcreteUIListByPageName(string pageName)
        {
            List<IConcreteUI> result = new List<IConcreteUI>();
            Page page = _pageService.GetByPageName(pageName, false);
            var pageData = page.CreateIDataList();
            foreach (var data in pageData)
            {
                var uI = CreateUI(data);
                result.Add(uI);
            }
            return result;
        }

        private IConcreteUI CreateUI(IData data)
        {
            switch (data.UIConcreteType)
            {
                case UIConcrete.Head:
                    return new Concrete.Head.Head((Head)data,(MetaService?)_metaService,(JsonLDService?)_jsonLDService);
                    break;
                case UIConcrete.Card:
                    return new Concrete.Shared.Card.Card((Card)data,(AltService?)_altService,(JsonLDService?) _jsonLDService);
                    break;
                case UIConcrete.Carousel:
                    return new Concrete.Carousel.Carousel((Carousel)data, (JsonLDService?)_jsonLDService, (AltService?)_altService);
                    break;
                case UIConcrete.CarouselCard:
                    return new Concrete.CarouselCard.CarouselCard((CarouselCard)data, (JsonLDService?)_jsonLDService, (AltService?)_altService);
                    break;
                case UIConcrete.InformationBlock:
                    return new Concrete.InformationBlock.InformationBlock((InfomatonBlock)data, (JsonLDService?)_jsonLDService, (AltService?)_altService);
                    break;
                case UIConcrete.Table:
                    return new Concrete.Table.Table((Table)data, (JsonLDService?)_jsonLDService);
                    break;
                case UIConcrete.Video:
                    return new Concrete.Video.Video((Video)data, (JsonLDService?)_jsonLDService);
                    break;
                default:
                    throw new Exception("UIConcreteType not found");
                    break;
            }
        }
    }
}