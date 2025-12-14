using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult;
using Page_Library.Page.Entities.SearchResult.Interface;
using Page_Library.Page.Factory.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Page.Service.Interface;

namespace Page_Library.Page.Service.Base
{
    public abstract class PageServiceBase : IPageService
    {
        private protected readonly IPageRepository _pageRepository;
        private protected readonly IContentBlockFactory _contentBlockFactory;
        private protected readonly IContentRepository _contentRepository;

        public PageServiceBase(IPageRepository pageRepository, IContentBlockFactory contentBlockFactory, IContentRepository contentBlockRepository)
        {
            _pageRepository = pageRepository;
            _contentRepository = contentBlockRepository;
            _contentBlockFactory = contentBlockFactory;
        }

        public IPage GetPage(string Id)
        {
            var results = _pageRepository.GetPage(Id);
            results.SetUpPolymorphContentBlocks(_contentRepository, _contentBlockFactory);
            results.Meta.SetContent(_contentRepository);
            return results;
        }

        private List<ISearchResult> createSearchResults(List<IPage> pages)
        {
            var toReturn = new List<ISearchResult>();
            foreach (IPage page in pages)
            {
                page.Meta.SetContent(_contentRepository);
                var SearchResult = new SearchResult(page);
                toReturn.Add(SearchResult);
            }

            return toReturn;
        }

        public List<ISearchResult> Search(string searchTerm, string category)
        {
            try
            {
                List<IPage> pages = _pageRepository.GetPages(searchTerm, category);
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
