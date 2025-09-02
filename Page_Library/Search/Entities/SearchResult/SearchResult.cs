using Page_Library.Search.Entities.SearchResult.Base;
using Page_Library.Search.Entities.SearchResult.DTO;

namespace Page_Library.Search.Entities.SearchResult
{
    public class SearchResult : SearchResultBase
    {
        public SearchResult(SearchResultDTO dto) : base(dto)
        {
        }
    }
}
