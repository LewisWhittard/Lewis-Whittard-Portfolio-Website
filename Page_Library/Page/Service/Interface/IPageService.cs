using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult.Interface;

namespace Page_Library.Page.Service.Interface
{
    public interface IPageService
    {
        public IPage GetPage(string id);
        public List<ISearchResult> Search(string searchTerm, string category);
    }
}
