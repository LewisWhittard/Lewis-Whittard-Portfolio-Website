using Page_Library.Search.Entities.SearchResult.Interface;

namespace Page_Library.Search.Repository.Interface;

public interface IPageSearchRepository
{
    public abstract List<ISearchResult> Search();

    public abstract List<ISearchResult> Search(int Id,
            bool programming,
            bool testing,
            bool games,
            bool threeDAssets,
            bool twoDAssets,
            bool blog);
}
