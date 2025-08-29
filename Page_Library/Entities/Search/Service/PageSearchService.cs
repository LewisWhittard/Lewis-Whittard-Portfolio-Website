using Page_Library.Entities.Search.Entities.SearchResult.Interface;
using Page_Library.Entities.Search.Repository.Interface;

namespace Page_Library.Entities.Search.Service
{
    public class PageSearchService : PageSearchServiceBase
    {
        public PageSearchService(IPageSearchRepository Repository) : base(Repository)
        {
        }

        public override List<ISearchResult> Search()
        {
            try
            {
                return _repository.Search();
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
                return _repository.Search(id, programming, testing, games, threeDAssets, twoDAssets, blog);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while searching with ID: {id}.", ex);
            }
        }


    }
}
