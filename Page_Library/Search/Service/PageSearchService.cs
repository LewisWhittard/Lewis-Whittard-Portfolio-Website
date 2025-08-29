using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Repository.Interface;
using Page_Library.Search.Service.Base;

namespace Page_Library.Search.Service
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
                return _repository.Search().ToList() ?? new List<ISearchResult>();
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
