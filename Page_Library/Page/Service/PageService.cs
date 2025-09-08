using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Page.Service.Base;

namespace Page_Library.Page.Service
{
    public abstract class PageService : PageServiceBase
    {
        public PageService(IPageRepository pageRepository) : base(pageRepository)
        {
        }

    }
}