using Page_Library.Entities.Search.Entities.SearchResult.Base;
using Page_Library.Entities.Search.Entities.SearchResult.Interface;
using Page_Library.Entities.Search.Repository.Interface;

namespace Page_Library.Entities.Search.Repository.Base
{
    public abstract class PageSearchRepositoryBase : IPageSearchRepository
    {
        public abstract List<ISearchResult> Search();

        public abstract List<ISearchResult> Search(int Id);
    }
}
