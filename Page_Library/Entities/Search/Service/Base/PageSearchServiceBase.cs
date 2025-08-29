using Page_Library.Entities.Search.Entities.SearchResult.Interface;
using Page_Library.Entities.Search.Repository.Interface;

namespace Page_Library.Entities.Search.Service
{
    public abstract class PageSearchServiceBase : IPageSearchRepository
    {
        private protected readonly IPageSearchRepository _repository;

        protected PageSearchServiceBase(IPageSearchRepository Repository)
        {
            _repository = Repository;
        }

        public abstract List<ISearchResult> Search();

        public abstract List<ISearchResult> Search(int Id);
    }
}
