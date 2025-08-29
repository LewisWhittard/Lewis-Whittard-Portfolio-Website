using Page_Library.Entities.Search.Entities.SearchResult.Base;

namespace Page_Library.Entities.Search.Entities.SearchResult
{
    public class SearchResult : SearchResultBase
    {
        public SearchResult(long id, string title, string description, long imageID, string category) : base(id, title, description, imageID, category)
        {
        }
    }
}
