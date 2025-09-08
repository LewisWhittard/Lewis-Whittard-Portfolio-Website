using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Factory.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Page.Service.Interface;

namespace Page_Library.Page.Service.Base
{
    public abstract class PageServiceBase : IPageService
    {
        private protected readonly IPageRepository _pageRepository;
        private protected readonly IContentBlockFactory _contentBlockFactory;
        private protected readonly IContentRepository _contentRepository;

        public PageServiceBase(IPageRepository pageRepository, IContentBlockFactory contentBlockFactory)
        {
            _pageRepository = pageRepository;
        }

        public IPage GetPage(int Id)
        {
            var results = _pageRepository.GetPage(Id);
            results.SetUpPolymorphContentBlocks(_contentRepository, _contentBlockFactory);
            return _pageRepository.GetPage(Id);
        }
    }
}
