using Page_Library.Content.Repository.Interface;
using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Repository.Interface;
using Page_Library.Search.Service.Interface;

namespace Page_Library.Search.Service.Base
{
    public abstract class PageSearchServiceBase : IPageSearchService
    {
        private protected readonly IPageSearchRepository _PageSearchRepository;
        private protected readonly IContentRepository _ContentRepository;

        protected PageSearchServiceBase(IPageSearchRepository PageSearchRepository, IContentRepository ContentRepository)
        {
            _PageSearchRepository = PageSearchRepository;
            _ContentRepository = ContentRepository;
        }

        public abstract List<ISearchResult> Search();

        public abstract List<ISearchResult> Search(string searchTerm, bool programming, bool testing, bool games, bool threeDAssets, bool twoDAssets, bool blog);
    }
}
