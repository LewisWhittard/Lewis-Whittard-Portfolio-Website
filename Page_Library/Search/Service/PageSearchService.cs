using Page_Library.Content.Entities.Content;
using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Interface;
using Page_Library.Search.Entities.SearchResult;
using Page_Library.Search.Entities.SearchResult.DTO;
using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Service.Base;

namespace Page_Library.Search.Service
{
    public class PageSearchService : PageSearchServiceBase
    {
        public PageSearchService(IPageRepository PageRepository, IContentRepository ContentRepository) : base(PageRepository, ContentRepository)
        {
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
                var pages = _PageRepository.GetPages(searchTerm, category);

                List<ISearchResult> toReturn = new List<ISearchResult>();

                foreach (var item in searchResults)
                {



                    if (content is Image imageContent)
                    {
                        item.SetContent(imageContent);
                    }
                    else
                    {
                        throw new InvalidCastException($"Content with ID {item.ContentID} is not of type Image.");
                    }


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
