using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Search.Entities.SearchResult;
using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Service.Base;

namespace Page_Library.Search.Service
{
    public class PageSearchService : PageSearchServiceBase
    {
        public PageSearchService(IPageRepository PageRepository, IContentRepository ContentRepository) : base(PageRepository, ContentRepository)
        {
        }
    }
}
