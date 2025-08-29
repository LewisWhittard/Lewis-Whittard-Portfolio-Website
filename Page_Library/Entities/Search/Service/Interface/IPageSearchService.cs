using Page_Library.Entities.Search.Entities.SearchResult.Interface;

namespace Page_Library.Entities.Search.Service.Interface
{
    public interface IPageSearchService
    {
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
