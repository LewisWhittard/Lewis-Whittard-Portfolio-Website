using Infrastructure.Repository.Interface;
using Infrastructure.Service.Page.Interface;

namespace Infrastructure.Service.Page
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public PageService()
        {
            
        }

        public Models.Data.Page.Page Get(string PageName)
        {
            return _pageRepository.GetByPageName(PageName);
        }
    }
}
