using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Repository.Interface;

namespace Page_Library.Search.Repository.Base
{
    public abstract class PageSearchRepositoryBase : IPageSearchRepository
    {

        public abstract List<ISearchResult> Search(string searchTerm,
            bool programming,
            bool testing,
            bool games,
            bool threeDAssets,
            bool twoDAssets,
            bool blog);
    }
}
