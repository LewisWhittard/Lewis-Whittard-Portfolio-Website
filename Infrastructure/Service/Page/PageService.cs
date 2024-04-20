using Infrastructure.Models.Data.Interface;
using Infrastructure.Repository.Page;
using Infrastructure.Repository.Page.Interface;
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
        
        public Models.Data.Page.Page GetByPageName(string PageName)
        {
            return _pageRepository.GetByPageName(PageName);
        }

        public List<IData> GetByPageNameAsIDataList(string PageName)
        {
            return _pageRepository.GetByPageName(PageName).CreateIDataList();
        }
    }
}
