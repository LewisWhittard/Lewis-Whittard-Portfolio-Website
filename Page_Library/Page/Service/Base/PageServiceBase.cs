using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Page.Service.Interface;

namespace Page_Library.Page.Service.Base
{
    public abstract class PageServiceBase : IPageService
    {
        private protected readonly IPageRepository _pageRepository;

        public PageServiceBase(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public abstract IPage GetPage(int Id);
    }
}
