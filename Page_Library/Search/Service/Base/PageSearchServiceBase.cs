using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Repository.Interface;
using Page_Library.Search.Service.Interface;

namespace Page_Library.Search.Service.Base
{
    public abstract class PageSearchServiceBase : IPageSearchService
    {
        private protected readonly IPageSearchRepository _repository;

        protected PageSearchServiceBase(IPageSearchRepository Repository)
        {
            _repository = Repository;
        }

        public abstract List<ISearchResult> Search();

        public abstract List<ISearchResult> Search(int id,
            bool programming,
            bool testing,
            bool games,
            bool threeDAssets,
            bool twoDAssets,
            bool blog);
    }
}
