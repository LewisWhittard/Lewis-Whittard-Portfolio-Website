using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Search.Entities.SearchResult.Base;
using Page_Library.Search.Entities.SearchResult.DTO;

namespace Page_Library.Search.Entities.SearchResult
{
    public class SearchResult : SearchResultBase
    {
        public SearchResult(IPage dto) : base(dto)
        {
        }


    }
}
