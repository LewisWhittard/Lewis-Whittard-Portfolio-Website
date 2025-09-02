using System.Collections.Generic;
using Page_Library.Search.Entities.SearchResult.Interface;

namespace LMWDev.Models
{
	public class SearchViewModel
	{
		public string Search { get; set; }
        public bool GamesCategory { get; set; } = true;
        public bool ProgrammingCategory { get; set; } = true;
        public bool TestingCategory { get; set; } = true;
        public bool ThreeDAssetsCategory { get; set; } = true;
        public bool TwoDAssetCategory { get; set; } = true;
        public bool BlogCategory { get; set; } = true;
        public bool FlexibleMeta = false;

		public List<ISearchResult> Results { get; set; }

        public SearchViewModel()
        {

        }

        public SearchViewModel(List<ISearchResult> results)
        {
			Results = results;
            GamesCategory = true;
            ProgrammingCategory = true;
            TestingCategory = true;
            ThreeDAssetsCategory = true;
            TwoDAssetCategory = true;
            BlogCategory = true;
        }
        
        
        public SearchViewModel(
        string search,
        bool gamesCategory,
        bool programmingCategory,
        bool testingCategory,
        bool threeDAssetsCategory,
        bool twoDAssetCategory,
        bool blogCategory,
        List<ISearchResult> results)
        {
            Search = search;
            GamesCategory = gamesCategory;
            ProgrammingCategory = programmingCategory;
            TestingCategory = testingCategory;
            ThreeDAssetsCategory = threeDAssetsCategory;
            TwoDAssetCategory = twoDAssetCategory;
            BlogCategory = blogCategory;
            Results = results;
        }
    }
	
}
