using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Content.Repository.Interface;
using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Repository.Interface;
using Page_Library.Search.Service.Base;

namespace Page_Library.Search.Service
{
    public class PageSearchService : PageSearchServiceBase
    {
        public PageSearchService(IPageSearchRepository PageSearchRepository, IContentRepository ContentRepository) : base(PageSearchRepository, ContentRepository)
        {
        }

        public override List<ISearchResult> Search(string searchTerm, bool programming, bool testing, bool games, bool threeDAssets, bool twoDAssets, bool blog)
        {
            try
            {
                var searchResults = _PageSearchRepository.Search(searchTerm, programming, testing, games, threeDAssets, twoDAssets, blog);

                List<ISearchResult> toReturn = new List<ISearchResult>();

                foreach (var item in searchResults)
                {
                    IContent content = _ContentRepository.GetContent(item.ContentID);
                    item.SetContent(content);
                    toReturn.Add(item);
                }

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
