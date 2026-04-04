using System.Collections.Generic;
using Page_Library.Page.Entities.SearchResult.Interface;

namespace LMWDev.Models
{
	public class SearchViewModel
	{
		public string Search { get; set; }
        public string Category { get; set; }
        public bool Meta = false;
        public bool ShouldNotBeIndexed { get; set; } = true;
        public bool BackgroundDisabled { get; set; }
        public string? JsonLD { get; set; }
        public bool IsCookieConsentBannerEnabled { get; set; }


        public List<ISearchResult> Results { get; set; }

        public SearchViewModel()
        {

        }

        public SearchViewModel(List<ISearchResult> results, bool backgroundDisabled, bool isCookieConsentBannerEnabled)
        {
			Results = results;
            Category = "All";
            BackgroundDisabled = backgroundDisabled;
            IsCookieConsentBannerEnabled = isCookieConsentBannerEnabled;
        }
        
        
        public SearchViewModel(
        string search,
        string category,
        List<ISearchResult> results)
        {
            Search = search;
            Category = category;
            Results = results;
        }
    }
	
}
