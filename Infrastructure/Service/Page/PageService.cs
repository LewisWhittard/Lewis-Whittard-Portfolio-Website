using Infrastructure.Models.Data.Interface;
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
        
        public Models.Data.Page.Page GetByPageName(string PageName, bool includeInactive)
        {
            if (includeInactive == true)
            {
                return _pageRepository.GetPages(PageName).Where(x => x.PageName == PageName && !x.Deleted).FirstOrDefault();
            }

            else
            {
                return _pageRepository.GetPages(PageName).Where(x => x.PageName == PageName && !x.Deleted && !x.Inactive).FirstOrDefault();
            }
        }

        public List<IData> GetByPageNameAsIDataList(string PageName, bool includeInactive)
        {
            if (includeInactive == true)
            {
                return _pageRepository.GetPages(PageName).Where(x => x.PageName == PageName && !x.Deleted).FirstOrDefault().CreateIDataList();
            }

            else
            {
                return _pageRepository.GetPages(PageName).Where(x => x.PageName == PageName && !x.Deleted && !x.Inactive).FirstOrDefault().CreateIDataList();
            }
        }
    }
}
