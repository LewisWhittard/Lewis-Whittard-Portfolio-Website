using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Search.Entities.SearchResult;
using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Service.Interface;

namespace Page_Library.Search.Service.Base
{
    public abstract class PageSearchServiceBase : IPageSearchService
    {
        private protected readonly IPageRepository _PageRepository;
        private protected readonly IContentRepository _ContentRepository;

        protected PageSearchServiceBase(IPageRepository PageRepository, IContentRepository ContentRepository)
        {
            _PageRepository = PageRepository;
            _ContentRepository = ContentRepository;
        }

        private List<ISearchResult> createSearchResults(List<IPage> pages)
        {
            var toReturn = new List<ISearchResult>();
            foreach (IPage page in pages)
            {
                page.Meta.SetContent(_ContentRepository);
                var SearchResult = new SearchResult(page);
                toReturn.Add(SearchResult);
            }

            return toReturn;
        }

        public override List<ISearchResult> Search(string searchTerm, string category)
        {
            try
            {
                List<IPage> pages = _PageRepository.GetPages(searchTerm, category);
                var toReturn = createSearchResults(pages);
                toReturn.Reverse();
                return toReturn;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while searching with ID: {searchTerm}.", ex);
            }
        }
    }
}
