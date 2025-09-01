using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Content.Repository.Interface;
using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Repository.Interface;
using Page_Library.Search.Service.Base;
using System.Reflection.Metadata;

namespace Page_Library.Search.Service
{
    public class PageSearchService : PageSearchServiceBase
    {
        public PageSearchService(IPageSearchRepository PageSearchRepository, IContentRepository ContentRepository) : base(PageSearchRepository, ContentRepository)
        {
        }

        public override List<ISearchResult> Search()
        {
            try
            {
                var searchResults = _PageSearchRepository.Search();

                List<ISearchResult> toReturn = new List<ISearchResult>();

                foreach (var item in searchResults)
                {
                    IContent content = _ContentRepository.GetContentById(item.ContentID);
                    item.SetContent(content);
                    toReturn.Add(item);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while performing a search operation.", ex);
            }
        }



        public override List<ISearchResult> Search(
            int id,
            bool programming,
            bool testing,
            bool games,
            bool threeDAssets,
            bool twoDAssets,
            bool blog)
        {
            try
            {
                var searchResults = _PageSearchRepository.Search(id, programming, testing, games, threeDAssets, twoDAssets, blog);

                List<ISearchResult> toReturn = new List<ISearchResult>();
                
                foreach (var item in searchResults)
                {
                    IContent content  =_ContentRepository.GetContentById(item.ContentID);
                    item.SetContent(content);
                    toReturn.Add(item);
                }

                toReturn.Reverse();
                return toReturn;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while searching with ID: {id}.", ex);
            }
        }


    }
}
