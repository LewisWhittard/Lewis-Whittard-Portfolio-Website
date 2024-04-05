using Infrastructure.Models.Data.Page;
using Infrastructure.Models.Data.Page.Interface;
using Infrastructure.Repository.Interface;
using Infrastructure.Service.Interface;

namespace Infrastructure.Service
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository) 
        {
            _pageRepository = pageRepository;
        }

        public Page Get(string PageName)
        {
            return _pageRepository.Get(PageName);
        }
    }
}
