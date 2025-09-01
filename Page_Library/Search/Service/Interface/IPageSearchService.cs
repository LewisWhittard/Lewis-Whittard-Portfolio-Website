using Page_Library.Search.Entities.SearchResult.Interface;

namespace Page_Library.Search.Service.Interface
{
    public interface IPageSearchService
    {
        public abstract List<ISearchResult> Search();

        public abstract List<ISearchResult> Search(string searchTerm,
            bool programming,
            bool testing,
            bool games,
            bool threeDAssets,
            bool twoDAssets,
            bool blog);
    }
}
