using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Factory.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Page.Service.Base;

namespace Page_Library.Page.Service
{
    public class PageService : PageServiceBase
    {
        public PageService(IPageRepository pageRepository, IContentBlockFactory contentBlockFactory, IContentRepository contentBlockRepository) : base(pageRepository, contentBlockFactory, contentBlockRepository)
        {
        }
    }
}