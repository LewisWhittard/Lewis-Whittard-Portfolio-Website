using System.Collections.Generic;
using Page_Library.Page.Entities.SearchResult.Interface;

namespace LMWDev.Models
{
	public class SearchViewModel
	{
		public string Search { get; set; }
        public string Category { get; set; }
        public bool Meta = false;

        public List<ISearchResult> Results { get; set; }

        public SearchViewModel()
        {

        }

        public SearchViewModel(List<ISearchResult> results)
        {
			Results = results;
            Category = "All";
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
