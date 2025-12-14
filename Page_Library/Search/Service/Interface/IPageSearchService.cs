using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Search.Entities.SearchResult.Interface;

namespace Page_Library.Search.Service.Interface
{
    public interface IPageSearchService
    {

        public List<ISearchResult> Search(string searchTerm, string category);
    }
}
