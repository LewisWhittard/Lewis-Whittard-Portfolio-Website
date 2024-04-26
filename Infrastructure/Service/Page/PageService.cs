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
        
        public Models.Data.Page.Page GetByPageName(string pageName, bool includeInactive)
        {
            if (includeInactive == true)
            {
                return _pageRepository.GetPages(pageName).Where(x => x.PageName == pageName && !x.Deleted).FirstOrDefault();
            }

            else
            {
                return _pageRepository.GetPages(pageName).Where(x => x.PageName == pageName && !x.Deleted && !x.Inactive).FirstOrDefault();
            }
        }

        public List<IData> GetByPageNameAsIDataList(string pageName, bool includeInactive)
        {
            return GetByPageName(pageName,includeInactive).CreateIDataList();
        }
    }
}
