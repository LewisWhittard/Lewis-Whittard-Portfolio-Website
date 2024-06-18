using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Interface;
using Infrastructure.Service.Page.Interface;
using SEO.Service.JsonLDService.Interface;
using SEO.Service.AltService.Interface;
using SEO.Service.MetaService.Interface;
using Infrastructure.Models.Data.Page;
using UIFactory.Factory.Concrete.Interface;

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

        public List<IConcreteUI> CreateUIListByPageName(string pageName)
        {
            List<IConcreteUI> result = new List<IConcreteUI>();
            Page page = _pageService.GetByPageName(pageName, false);
            var pageData = page.CreateIDataList();
            foreach (var data in pageData)
            {
                var uI = CreateUI(data,true,true,true);
                result.Add(uI);
            }
            return result;
        }

        private IConcreteUI CreateUI(IData data, bool jsonLD, bool alt, bool meta)
        {
            switch (data.UIConcreteType)
            {
                case UIConcrete.Head:
                    return null;
                    break;
                case UIConcrete.Card:
                    return null;
                    break;
                case UIConcrete.Carousel:
                    return null;
                    break;
                case UIConcrete.CarouselCard:
                    return null;
                    break;
                case UIConcrete.InformationBlock:
                    return null;
                    break;
                case UIConcrete.Table:
                    return null;
                    break;
                case UIConcrete.Video:
                    return null;
                    break;
                default:
                    throw new Exception("UIConcreteType not found");
                    break;
            }
        }
    }
}