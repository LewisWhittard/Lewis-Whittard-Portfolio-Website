using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Factory.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Page.Service.Base;

namespace Page_Library.Page.Service
{
    public abstract class PageService : PageServiceBase
    {
        protected PageService(IPageRepository pageRepository, IContentBlockFactory contentBlockFactory, IContentRepository contentBlockRepository) : base(pageRepository, contentBlockFactory, contentBlockRepository)
        {
        }
    }
}