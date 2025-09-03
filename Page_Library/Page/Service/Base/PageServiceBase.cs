using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Interface;

namespace Page_Library.Page.Service.Base
{
    public abstract class PageServiceBase : IPageRepository
    {
        private readonly IPageRepository _pageRepository;

        public PageServiceBase(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public abstract List<IPage> GetPage(int Id);
    }
}
